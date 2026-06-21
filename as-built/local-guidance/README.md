# Local Guidance

Status: Non-normative operator guidance for local-agent execution.

Files in this folder are numbered in intended reading or execution order.

## Files

| Order | File | Purpose |
| --- | --- | --- |
| `0001` | `0001-run-single-work-packet-with-ollama.ps1` | Runs one bounded work packet through an Ollama model on a per-packet Git branch and asks for a patch proposal only. |
| `0002` | `0002-operator-review-checklist.md` | Checklist for reviewing local-agent output before accepting or rejecting it. |
| `0003` | `0003-apply-local-agent-patch.ps1` | Applies a saved `.patch` file, then runs tests and build sequentially. |

## Usage

For Sage-X-only work, from the `Sagex.Engine` root:

```powershell
.\as-built\local-guidance\0001-run-single-work-packet-with-ollama.ps1 -PacketId "WP-0007.1" -Model "qwen2.5-coder:14b" -ContextProfile "sagex"
```

For ISL plugin or bridge work:

```powershell
.\as-built\local-guidance\0001-run-single-work-packet-with-ollama.ps1 -PacketId "WP-0101.1" -Model "qwen2.5-coder:14b" -ContextProfile "sagex-isl"
```

By default, the script:

- refuses to run if the working tree has uncommitted changes
- creates or switches to `local-agent/<packet-id>`
- asks Ollama for a patch proposal only

Review the proposed patch before applying changes. Then run:

```powershell
dotnet test Sagex.Engine.slnx
dotnet build Sagex.Engine.slnx
```

If applied changes are not acceptable and remain uncommitted:

```powershell
git restore .
git clean -fd
```

Record accepted and rejected attempts in:

`as-built\local-agent-runs.md`

## Applying A Saved Patch

```powershell
.\as-built\local-guidance\0003-apply-local-agent-patch.ps1 -PatchPath ".\local-agent-output\WP-0101.1.patch"
```

If the patch fails review after application and remains uncommitted:

```powershell
git restore .
git clean -fd
```
