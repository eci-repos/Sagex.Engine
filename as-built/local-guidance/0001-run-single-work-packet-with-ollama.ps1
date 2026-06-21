param(
    [string]$Model = "qwen2.5-coder:14b",
    [string]$PacketId = "WP-0101.1",
    [ValidateSet("sagex", "sagex-isl")]
    [string]$ContextProfile = "sagex",
    [bool]$CreateTaskBranch = $true,
    [string]$BranchPrefix = "local-agent",
    [switch]$AllowDirtyWorkingTree,
    [string]$EngineRoot = "C:\Users\esobr\source\repos\Sagex.Engine",
    [string]$SpecRoot = "C:\Users\esobr\source\repos\Imhotep.Specifications"
)

$ErrorActionPreference = "Stop"

$basePacketId = $PacketId -replace "\.\d+$", ""

Set-Location $EngineRoot

git rev-parse --is-inside-work-tree | Out-Null

$status = git status --porcelain
if ($status -and -not $AllowDirtyWorkingTree) {
    throw "Working tree has uncommitted changes. Commit/stash them first, or rerun with -AllowDirtyWorkingTree."
}

if ($CreateTaskBranch) {
    $safePacketId = $PacketId -replace "[^A-Za-z0-9._-]", "-"
    $taskBranch = "$BranchPrefix/$safePacketId"
    $currentBranch = git branch --show-current
    $branchExists = git branch --list $taskBranch

    if ($currentBranch -ne $taskBranch) {
        if ($branchExists) {
            git checkout $taskBranch | Out-Null
        }
        else {
            git checkout -b $taskBranch | Out-Null
        }
    }
}

$planPath = Join-Path $SpecRoot "specs\implementation planning\sagex-to-isl.implementation.execution-plan.json"
$plan = Get-Content $planPath -Raw | ConvertFrom-Json
$packet = $plan.steps | Where-Object { $_.step_id -eq $basePacketId } | Select-Object -First 1

if ($null -eq $packet) {
    throw "Formal work packet '$basePacketId' was not found in $planPath."
}

$packetJson = $packet | ConvertTo-Json -Depth 20

$contextFiles = @(
    "as-built\local-agent-context-pack.sagex.md",
    "as-built\implementation-progress.md",
    "as-built\continuation-protocol.md"
)

if ($ContextProfile -eq "sagex-isl") {
    $contextFiles += @(
        "as-built\local-agent-context-pack.isl.md",
        "as-built\isl-context-strategy-reconciliation.md"
    )
}

$context = foreach ($file in $contextFiles) {
    $path = Join-Path $EngineRoot $file

    if (-not (Test-Path -LiteralPath $path)) {
        throw "Required context file was not found: $path"
    }

    "`n--- FILE: $file ---`n"
    Get-Content -LiteralPath $path -Raw
}

$prompt = @"
You are the local Sagex.Engine construction agent.

Work on ONLY this packet: $PacketId
Base formal packet: $basePacketId
Context profile: $ContextProfile

Formal packet detail:
$packetJson

Context:
$context

Rules:
- Do not work beyond $PacketId.
- Do not modify normative specs.
- Keep Sage-X specification-agnostic.
- Treat the current milestone or phase as the active Construction Boundary.
- Treat context packs as minimized Connection Contexts.
- First state the active Construction Boundary, current packet, planned files, and validation commands.
- Then propose a patch/diff only.
- Do not claim completion until tests/build are run by the operator.
- Assume the operator will review the patch on a per-packet Git branch before accepting it.

Additional rule when ContextProfile is sagex-isl:
- Treat ISL as a plugin/profile, not hardcoded core behavior.

Expected validation:
dotnet test Sagex.Engine.slnx
dotnet build Sagex.Engine.slnx

Rollback if unaccepted and uncommitted:
git restore .
git clean -fd
"@

$prompt | ollama run $Model
