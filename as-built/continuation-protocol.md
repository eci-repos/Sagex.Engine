# Sagex.Engine Continuation Protocol

Status: Non-normative local agent operating protocol.

This protocol is the local-first implementation discipline for ISL r2 Construction Boundary, Connection Context, and Boundary Continuation Record behavior. It does not replace the normative ISL model.

Use this protocol at the start and end of every local-agent session.

## Session Start

Read these files first:

1. `as-built/local-agent-context-pack.sagex.md`
2. `as-built/local-agent-context-pack.isl.md`
3. `as-built/implementation-progress.md`
4. `as-built/implementation-decisions.md`

Then state:

- active Construction Boundary or milestone
- current milestone
- current work packet
- planned subtask
- files likely to change
- validation commands

Do not begin coding until the current work packet is clear.

## Work Rules

- Work on one approved work packet at a time.
- Treat the current milestone or phase as the active Construction Boundary.
- Treat context packs as minimized Connection Contexts.
- Read only the relevant schema definition or spec section needed for that packet.
- Keep changes scoped to the packet.
- Add or update fixtures for schema-backed artifacts.
- Add or update tests with every behavioral change.
- Do not treat context packs or as-built files as normative specifications.
- Do not modify normative specs unless explicitly instructed.

## Validation

Before marking work complete, run:

```powershell
dotnet test Sagex.Engine.slnx
dotnet build Sagex.Engine.slnx
```

Run these sequentially, not in parallel.

## Session End

Before stopping, update:

1. `as-built/implementation-progress.md`
2. `as-built/implementation-decisions.md`, if an implementation choice was made
3. `as-built/local-runbook.md`, if commands or local operation changed

The progress file must clearly show:

- active or completed Construction Boundary
- completed work packet
- current execution point
- next pending work packet
- latest validation result
 - continuation summary for downstream work when a milestone/boundary completes

## Handoff Standard

Never leave the repository in an ambiguous state.

A future agent should be able to answer these questions in under one minute:

- What milestone are we in?
- What work packet is next?
- What was just completed?
- What files define the current context?
- Did build and tests pass?

## Drift Check

Before ending, check for drift:

- Did the work change Sage-X or ISL semantics without normative approval?
- Did the work skip schema-backed validation?
- Did the work lose traceability to a work packet, schema definition, or spec section?
- Did the work broaden beyond the approved packet?
- Did the work leave build or tests failing?

If yes, record the issue in `implementation-progress.md` before stopping.
