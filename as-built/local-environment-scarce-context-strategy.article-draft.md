# Working Locally With Scarce Agent Context

Status: Non-normative article draft.

## Why Local Agent Work Needs Context Discipline

Local development environments give teams control, privacy, speed, and ownership. They also introduce a practical constraint that is easy to underestimate: local agents often operate with scarce context windows.

An agent may only have 8k to 16k tokens available. That space must hold instructions, task history, relevant specifications, source code, tool output, and the actual reasoning needed to complete the work. If the agent loads too much, it loses precision. If it loads too little, it loses intent.

For specification-driven systems like Sage-X and ISL, this matters even more. The work is not just ordinary coding. The implementation must preserve normative language, schema contracts, traceability, governance boundaries, reuse decisions, and execution semantics. A local agent that forgets where it is in the plan can easily drift, duplicate work, misread a schema, or implement behavior that sounds right but violates the specification model.

The answer is not to give every local agent the full corpus every time. The answer is to manage context as a first-class engineering resource.

## The Core Problem

Large specification sets create three recurring risks in local agent workflows:

1. **Context overload**

   Loading full specifications consumes the working window before the agent reaches the task.

2. **Context loss**

   If the agent only sees a fragment, it may miss the governing rule, current milestone, or next work packet.

3. **Context drift**

   If progress is tracked only in conversation, future sessions may resume from memory, not from verified project state.

These risks are not signs that local agents are unsuitable. They are signs that local-agent work needs a continuation system.

## ISL Alignment

ISL r2 already defines the deeper strategy for this problem. The relevant ISL concepts are:

- **Construction Boundary**: a bounded planning and execution scope.
- **Connection Context**: the authorized, minimized, validated context allowed to cross boundaries.
- **Boundary Continuation Record**: durable information required by downstream boundaries to continue without conversational memory.

So the Sagex.Engine local strategy is not a separate invention. It is a local-first implementation of those ISL controls.

In our local workflow:

- milestones map to Construction Boundaries.
- work packets map to construction tasks inside a boundary.
- context packs map to minimized Connection Contexts.
- `implementation-progress.md` provides durable continuation state.
- `implementation-decisions.md` captures decision records.
- validation history captures evidence.
- the continuation protocol defines how local sessions produce handoff state.

## Recommended Strategy

The recommended strategy is to separate context into layers.

### 1. Keep Normative Specifications Separate

The full Sage-X and ISL specifications remain authoritative. They should not be rewritten into implementation notes, and implementation progress should not be mixed into normative documents.

Normative specs answer:

- What must be true?
- What semantics govern the system?
- What contracts define conformance?

Implementation notes answer:

- What have we built?
- What task is next?
- What local choices were made?

Keeping those separate prevents temporary implementation details from being mistaken for specification requirements.

### 2. Use Compact Context Packs

Instead of loading the full corpus, each local agent starts with compact context packs.

A context pack should act as a minimized Connection Context. It should:

- state that it is non-normative
- summarize current state
- identify the current milestone and work packet
- map to exact normative source files
- list operating rules
- name drift risks
- point to validation commands

The pack is not the source of truth. It is a map to the source of truth.

### 3. Work One Packet at a Time

The execution plan must be decomposed into small work packets. Each packet should have:

- one purpose
- explicit inputs
- one primary output
- one validation method
- clear traceability to a schema artifact or specification section

This keeps the agent’s loaded context small and makes review easier.

### 4. Load Only the Needed Source Detail

After reading the context pack, the local agent should load only the relevant schema definition, spec section, source file, or fixture needed for the current packet.

For example, if the task is to create an ISL plugin registration fixture, the agent should inspect the `specificationPluginRegistration` schema definition, not the entire platform schema and all ISL documents.

### 5. Maintain As-Built Records

Every session must leave a durable trail. In ISL terms, this is the local form of boundary continuation state.

At minimum, the project should maintain:

- progress tracker
- implementation decisions log
- local runbook
- continuation protocol
- compact context packs

These files allow a future agent to resume from repository state instead of from conversation memory.

### 6. Require Validation Before Completion

A work packet is not complete because the code was written. It is complete only when the expected validation passes.

For Sagex.Engine, the baseline validation is:

```powershell
dotnet test Sagex.Engine.slnx
dotnet build Sagex.Engine.slnx
```

These commands should be run sequentially to avoid output file locks.

## How Sagex.Engine Implements This Strategy

Sagex.Engine now uses a local context-management structure under:

`C:\Users\esobr\source\repos\Sagex.Engine\as-built`

The key files are:

- `implementation-progress.md`
- `implementation-decisions.md`
- `local-runbook.md`
- `continuation-protocol.md`
- `local-agent-context-pack.sagex.md`
- `local-agent-context-pack.isl.md`
- `isl-context-strategy-reconciliation.md`
- `local-agent-runs.md`
- `local-guidance/0001-run-single-work-packet-with-ollama.ps1`
- `local-guidance/0002-operator-review-checklist.md`
- `local-guidance/0003-apply-local-agent-patch.ps1`

The normative source remains in:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs`

This gives local agents a compact starting point while preserving high-resolution references back to the authoritative specifications.

The local guidance scripts add an operator-controlled execution layer:

- `0001` runs one bounded packet through Ollama and requests a patch proposal only.
- `0002` gives the operator a checklist for reviewing the output.
- `0003` applies a saved patch only after `git apply --check`, then runs tests and build.

The Ollama runner supports context profiles:

- `sagex` for Sage-X core work.
- `sagex-isl` for ISL plugin or bridge work.

This matters because Sage-X must remain specification-agnostic. ISL context is loaded only when the active work packet requires ISL plugin or bridge knowledge.

## Current Sagex.Engine Milestone

Sagex.Engine has reached:

`M0: Local Takeover-Ready Sagex.Engine Foundation`

That means the local foundation is in place:

- .NET 10 solution and project skeleton
- imported Sage-X platform schema
- schema loader
- schema definition index
- JSON Schema validator wrapper
- fixture convention
- fixture discovery contract tests
- passing build and test baseline
- as-built continuation records

The next work is Phase 1:

`WP-0101.1: Define ISL plugin registration fixture`

At this point, the local crew can continue with a controlled workflow. The agent does not need to remember everything. It needs to follow the continuation protocol.

## The Continuation Protocol

At the start of a session, the local agent reads:

1. `as-built/local-agent-context-pack.sagex.md`
2. `as-built/implementation-progress.md`
3. `as-built/implementation-decisions.md`
4. `as-built/continuation-protocol.md`

For ISL plugin or bridge work, it also reads:

- `as-built/local-agent-context-pack.isl.md`
- `as-built/isl-context-strategy-reconciliation.md`

Then it states:

- current milestone
- current work packet
- planned subtask
- likely files to change
- validation commands

At the end of a session, it updates:

- progress tracker
- decision log if a choice was made
- runbook if local commands changed
- local-agent run log if an Ollama/local-agent attempt was performed

The session should never end in an ambiguous state.

## Operator-Controlled Local Agent Runs

Sagex.Engine does not assume that local model output is automatically accepted.

The recommended flow is:

1. Start from a clean Git working tree.
2. Run one packet through the Ollama guidance script.
3. Keep the local model on a per-packet branch.
4. Ask for a patch proposal only.
5. Review the patch with the operator checklist.
6. Apply a saved patch with the patch helper.
7. Run tests and build.
8. Accept, reject, or roll back.
9. Record the attempt in `as-built/local-agent-runs.md`.

If applied changes are not acceptable and remain uncommitted, the operator can roll them back with:

```powershell
git restore .
git clean -fd
```

This creates a practical safety gate around local autonomous construction.

## Why This Works

This approach works because it treats context like memory hierarchy.

The full specifications are long-term authoritative memory.

The context packs are minimized Connection Contexts.

The progress tracker is durable continuation state.

The decision log is implementation rationale.

The runbook is operational memory.

The local-agent run log is acceptance evidence.

The guidance scripts are operator-controlled execution aids.

The tests are executable evidence.

Together, these make local-agent work practical even with small context windows.

## Conclusion

Local agents can successfully work on specification-heavy systems, but only if context is managed deliberately.

The goal is not to compress every specification into one giant prompt. The goal is to provide a stable map, a narrow task, durable progress records, and mandatory validation.

Sagex.Engine is implementing this through compact context packs, granular work packets, as-built records, and a strict continuation protocol. This gives the local crew enough guidance to move quickly while preserving the semantics, traceability, and governance required by Sage-X and ISL.
