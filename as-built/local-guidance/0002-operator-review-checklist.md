# Operator Review Checklist

Status: Non-normative review checklist for local-agent output.

Use this after running `0001-run-single-work-packet-with-ollama.ps1` and before accepting any local-agent changes.

## Packet Scope

- The output addresses only the requested packet.
- The output does not advance into the next packet.
- The output names the active Construction Boundary or milestone.
- The output names planned files before proposing changes.

## Specification Discipline

- Sage-X core behavior remains specification-agnostic.
- ISL behavior is treated as plugin/profile behavior when relevant.
- Normative specification files were not modified.
- Any referenced schema definition or spec section is named clearly.
- No context pack or as-built note is treated as normative.

## Patch Review

- The patch is small enough to review.
- The patch touches only expected files.
- New files follow existing folder conventions.
- Fixtures follow `fixtures/{valid|invalid}/{schema-definition-name}/{fixture-name}.json`.
- Tests are included for new behavior or fixture expectations.

## Traceability

- The work maps to the requested work packet.
- Schema-backed artifacts identify the schema definition they validate against.
- Any implementation decision is suitable for `as-built/implementation-decisions.md`.
- Progress update text is suitable for `as-built/implementation-progress.md`.

## Validation

Run sequentially:

```powershell
dotnet test Sagex.Engine.slnx
dotnet build Sagex.Engine.slnx
```

Acceptance requires:

- tests pass
- build passes
- 0 errors
- no unexpected warnings

## Reject Or Roll Back

Reject the output if it:

- changes unrelated files
- hardcodes specification-specific behavior into Sage-X core
- skips tests for behavioral changes
- modifies normative specs without instruction
- leaves the repository ambiguous
- fails build or tests

If changes were applied but not accepted:

```powershell
git restore .
git clean -fd
```

## Acceptance Record

After review, record the attempt in:

`as-built/local-agent-runs.md`
