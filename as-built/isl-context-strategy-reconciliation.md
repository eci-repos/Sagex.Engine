# ISL Context Strategy Reconciliation

Status: Non-normative reconciliation note.

## Purpose

This note reconciles the Sagex.Engine local-agent context strategy with ISL r2's autonomous construction controls.

The local strategy must not duplicate or bypass ISL. It should implement the same intent using local-first files and procedures.

## ISL Normative Source

Primary source:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\isl releases\isl release 2\isl r2 - v1.5 The Construction Planning Model.md`

Related source:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\isl releases\isl release 2\isl r2 - v3.6 The Autonomous Development Loop.md`

Relevant ISL concepts:

- Construction Boundary
- Connection Context
- Boundary Continuation Record
- durable state-controlled continuation
- context minimization for local/resource-constrained model profiles

## Reconciliation

Our local terms map to ISL terms as follows:

| Local Sagex.Engine Term | ISL r2 Term | Meaning |
| --- | --- | --- |
| Work packet | Construction task within a Construction Boundary | Small executable unit of work. |
| Milestone such as `M0` | Construction Boundary | Bounded scope with entry/exit criteria and validation. |
| Context pack | Connection Context / minimized context package | Authorized context transferred into a local-agent session. |
| Progress tracker | Durable loop/boundary state | State used to resume without conversational memory. |
| Continuation protocol | Boundary continuation procedure | Required start/end behavior for safe continuation. |
| Implementation decisions log | Decision records | Rationale produced during boundary execution. |
| Validation history | Validation result records | Evidence that boundary/task exit criteria passed. |
| Local runbook | Operational context for the active boundary | Commands and local execution instructions. |

## Required Adjustment

Going forward, local-agent work should use ISL language:

- Each milestone should be treated as a Construction Boundary.
- Each agent session should operate inside the active boundary.
- Context packs should be treated as minimized Connection Contexts.
- `implementation-progress.md` should act as the durable continuation state.
- At boundary completion, the progress file should record a continuation summary sufficient for downstream work.

## Current Boundary Interpretation

`M0: Local Takeover-Ready Sagex.Engine Foundation`

Boundary type:

`foundation`

Boundary status:

`completed`

Boundary outputs:

- solution skeleton
- platform schema copy
- schema loader
- definition index
- validator wrapper
- fixture convention
- fixture contract tests
- local runbook
- context packs
- continuation protocol

Next boundary:

`Phase 1: ISL Specification Plugin and Knowledge Layer`

First task:

`WP-0101.1: Define ISL plugin registration fixture`

## Drift Rule

If a local agent creates a new context file, handoff file, progress method, or resume mechanism, it must be checked against ISL's Construction Boundary, Connection Context, and Boundary Continuation Record model.

Do not create a parallel continuation system unless it is explicitly mapped back to ISL.
