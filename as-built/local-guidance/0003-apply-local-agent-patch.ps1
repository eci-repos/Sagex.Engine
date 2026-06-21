param(
    [Parameter(Mandatory = $true)]
    [string]$PatchPath,
    [string]$EngineRoot = "C:\Users\esobr\source\repos\Sagex.Engine",
    [switch]$AllowDirtyWorkingTree,
    [switch]$SkipValidation
)

$ErrorActionPreference = "Stop"

Set-Location $EngineRoot

if (-not (Test-Path -LiteralPath $PatchPath)) {
    throw "Patch file was not found: $PatchPath"
}

git rev-parse --is-inside-work-tree | Out-Null

$status = git status --porcelain
if ($status -and -not $AllowDirtyWorkingTree) {
    throw "Working tree has uncommitted changes. Commit/stash them first, or rerun with -AllowDirtyWorkingTree."
}

Write-Host "Checking patch..." -ForegroundColor Cyan
git apply --check $PatchPath

Write-Host "Applying patch..." -ForegroundColor Cyan
git apply $PatchPath

if ($SkipValidation) {
    Write-Host "Patch applied. Validation skipped by operator request." -ForegroundColor Yellow
    exit 0
}

Write-Host "Running tests..." -ForegroundColor Cyan
dotnet test Sagex.Engine.slnx

Write-Host "Running build..." -ForegroundColor Cyan
dotnet build Sagex.Engine.slnx

Write-Host "Patch applied and validation passed." -ForegroundColor Green
