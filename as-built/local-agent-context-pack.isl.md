# ISL Local Agent Context Pack

Status: Non-normative condensed operating brief for local agents.

This file is a compact working context for ISL-related implementation work in `Sagex.Engine`. It does not replace the normative ISL r2 specifications or the ISL-Sage-X Integration Profile. When there is conflict, the normative files in `Imhotep.Specifications` control.

## Current State

Project root:

`C:\Users\esobr\source\repos\Sagex.Engine`

Normative ISL r2 folder:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\isl releases\isl release 2`

Bridge profile:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\integration profiles\ISL-SageX Integration Profile.md`

Sage-X local context pack:

`C:\Users\esobr\source\repos\Sagex.Engine\as-built\local-agent-context-pack.sagex.md`

ISL context strategy reconciliation:

`C:\Users\esobr\source\repos\Sagex.Engine\as-built\isl-context-strategy-reconciliation.md`

Milestone `M0: Local Takeover-Ready Sagex.Engine Foundation` is complete.

Current execution point:

`WP-0101.1: Define ISL plugin registration fixture`

## ISL Role In This Engine

ISL is the IMHOTEP specification language and construction semantics authority.

Sage-X is the specification-agnostic execution platform.

The bridge admits ISL-authored or ISL-canonical specifications into Sage-X through a specification plugin, compiles them into Sage-X Knowledge Units, and preserves traceability back to ISL origin metadata.

Local agents must not fold ISL construction semantics into generic Sage-X execution mechanics. ISL-specific behavior belongs in plugin metadata, bridge adapters, profile configuration, or ISL-aware planning rules.

## Operating Rules

- Treat ISL r2 specs as normative for IMHOTEP construction semantics.
- Treat Sage-X v1r0 specs as normative for generic execution mechanics.
- Use the ISL-Sage-X Integration Profile for bridge rules.
- Reuse before construction: inspect existing Sage-X assets before authorizing new construction.
- Preserve traceability from ISL authored/canonical elements to Sage-X artifacts.
- Keep shared contracts explicit. Similar terms do not imply compatibility.
- Record evidence for reuse, compatibility, validation, provenance, and governance decisions.
- Do not silently reinterpret ISL readiness levels, construction boundaries, governance gates, or traceability semantics.
- Validate schema-backed artifacts with fixtures and contract tests.
- Keep as-built records non-normative.

## ISL r2 File Map

- `isl r2 - v0.0 IMHOTEP Specification Language.md`: corpus-level standard, conformance, system integrity.
- `isl r2 - v0.1 Schema and Conformance Artifact Model.md`: schema and conformance artifact model.
- `isl r2 - v0.1.1 language schema.json`: authored ISL language schema.
- `isl r2 - v0.1.2 canonical schema.json`: canonical semantic schema.
- `isl r2 - v1.0 ASC Language.md`: authored ASC/ISL language surface.
- `isl r2 - v1.1 Canonical Semantic Model.md`: canonical entities and normalization semantics.
- `isl r2 - v1.2 ASC Execution Model.md`: ASC execution semantics.
- `isl r2 - v1.3 Specification Readiness Levels.md`: readiness levels and progression.
- `isl r2 - v1.4 The Traceability Model.md`: traceability requirements.
- `isl r2 - v1.5 The Construction Planning Model.md`: construction planning model.
- `isl r2 - v1.6 The Tool Integration Model.md`: tool integration behavior.
- `isl r2 - v1.7 The Governance and Control Model.md`: governance, approval, and control.
- `isl r2 - v1.8 The Reusable Asset and Construction Reuse Model.md`: reuse model.
- `isl r2 - v2.0 The Platform Architecture Model.md`: IMHOTEP platform architecture.
- `isl r2 - v2.1 The Agent Collaboration Model.md`: multi-agent collaboration.
- `isl r2 - v2.2 The State and Memory Model.md`: state and memory.
- `isl r2 - v2.3 The Artifact Repository Model.md`: artifact repositories.
- `isl r2 - v2.4 The Execution Runtime Model.md`: execution runtime.
- `isl r2 - v2.5 The Model Integration and Abstraction Layer.md`: model abstraction.
- `isl r2 - v2.6 The Observability and Telemetry Model.md`: observability and telemetry.
- `isl r2 - v2.7 The Enterprise Deployment and Scaling Model.md`: deployment and scale.
- `isl r2 - v3.0 The Reference Implementation Architecture.md`: reference architecture.
- `isl r2 - v3.1 The Reference Repository Layout and Service Topology.md`: reference layout and topology.
- `isl r2 - v3.2 The Reference Construction Pipeline.md`: construction pipeline.
- `isl r2 - v3.3 The Reference Construction Scenario.md`: reference scenario.
- `isl r2 - v3.4 The Agent Implementation Model.md`: agent implementation.
- `isl r2 - v3.5 The Runtime Orchestration Architecture.md`: orchestration architecture.
- `isl r2 - v3.6 The Autonomous Development Loop.md`: autonomous development loop.
- `isl r2 - v3.7 The Autonomous Software Development Lifecycle Model.md`: autonomous SDLC.
- `isl r2 - v3.8 The Model Interaction Protocol.md`: model interaction protocol.
- `isl r2 - v3.9 The Tool Plugin Architecture.md`: tool plugin architecture.
- `isl r2 - v3.10 The Platform Security Architecture.md`: security architecture.
- `isl r2 - v4.0 The IMHOTEP Platform Vision and Ecosystem.md`: platform vision and ecosystem.

## Bridge Profile Essentials

The ISL-Sage-X Integration Profile defines:

- how ISL authored and canonical specifications are admitted into Sage-X.
- how ISL canonical entities map to Sage-X Knowledge Units.
- how ISL construction plans map to Sage-X execution plans.
- how Sage-X assets are registered as reusable construction assets.
- how ISL planning discovers, evaluates, selects, wraps, extends, composes, forks, or rejects Sage-X code.
- how shared schemas and contracts are classified.
- how governance decisions authorize reuse.
- how traceability is preserved from ISL specification intent to Sage-X artifacts and IMHOTEP outputs.
- how conformance is evaluated for the bridge layer.

Key bridge principle:

ISL owns construction semantics. Sage-X owns execution mechanics.

## Terms To Preserve

- ISL: IMHOTEP Specification Language and semantic authority for construction.
- Sage-X: specification-agnostic execution platform.
- ISL Specification Plugin: Sage-X plugin that ingests ISL authored/canonical specs and produces Knowledge Units.
- Knowledge Unit: Sage-X atomic structured representation derived from a specification element.
- Canonical Entity: normalized ISL semantic object.
- Construction Need: planned ISL requirement for code, schema, interface, engine behavior, tests, policy, infrastructure, or artifact.
- Sage-X Asset: existing reusable Sage-X code, schema, engine, adapter, test, trace, state, governance, or deployment artifact.
- Reuse Mode: use-as-is, wrap, extend, compose, fork, generate-new, reject, or escalate.
- Shared Contract: schema/interface/event/record/API usable by both systems without semantic contradiction.

## Current Implementation Foundation

Available in `Sagex.Engine`:

- platform schema copy under `schemas\platform`.
- schema loader.
- schema definition index.
- JSON Schema validator wrapper.
- valid/invalid fixture convention.
- fixture discovery contract tests.
- M0 local runbook.
- Sage-X context pack.

Latest known validation:

- `dotnet test Sagex.Engine.slnx`: passed, 21 tests.
- `dotnet build Sagex.Engine.slnx`: passed, 0 warnings, 0 errors.

## Next Work: ISL Plugin Registration

Next packet:

`WP-0101.1: Define ISL plugin registration fixture`

Relevant Sage-X schema definition:

`specificationPluginRegistration`

Likely fixture location:

`fixtures\valid\specificationPluginRegistration\isl-plugin-registration.json`

Expected approach:

1. Inspect `specificationPluginRegistration` in `schemas\platform\sagex.00.v1r0.platform-schema.json`.
2. Create the minimal valid ISL plugin registration fixture using exact required fields.
3. Use plugin identity that clearly identifies ISL r2.
4. Include traceable source references to the ISL r2 folder and bridge profile where schema allows.
5. Let the fixture contract harness validate it by folder convention.
6. Run tests and build.
7. Update `as-built\implementation-progress.md`.

Do not implement the registry in this packet unless the work packet is explicitly advanced to `WP-0102`.

## Phase 1 Direction

Phase 1 goal:

Implement the first ISL-compatible specification ingestion path.

Near-term work:

- `WP-0101`: ISL plugin registration fixture.
- `WP-0102`: plugin registry.
- `WP-0103`: valid specification ingestion fixture.
- `WP-0104`: invalid specification ingestion fixture.
- `WP-0105`: ingestion validator.
- `WP-0106`: parsed specification model output.
- `WP-0107`: plugin validation result writer.
- `WP-0108`: Knowledge Unit mapper.
- `WP-0109`: local Knowledge Unit store.

Exit criteria:

- minimal ISL fixture can be ingested.
- invalid fixture content is rejected with structured errors.
- valid fixture content produces deterministic Knowledge Units.
- Knowledge Units preserve origin metadata.

## Validation Protocol

Run these before marking any task complete:

```powershell
dotnet test Sagex.Engine.slnx
dotnet build Sagex.Engine.slnx
```

Do not run build and test in parallel against the same output folders.

## Drift Warnings

Flag drift if local work:

- changes ISL semantics without modifying the normative ISL specs.
- treats the context pack as normative.
- treats Sage-X generic execution behavior as ISL construction semantics.
- creates ISL bridge behavior without traceability to ISL r2 and the bridge profile.
- skips reusable asset assessment where reuse is relevant.
- fails to preserve origin metadata in ISL-derived artifacts.
- skips schema-backed fixtures.
- proceeds beyond the current work packet without recording progress.

## Fast Resume Checklist

1. Read this file.
2. Read `as-built\local-agent-context-pack.sagex.md`.
3. Read `as-built\implementation-progress.md`.
4. Read `as-built\implementation-decisions.md`.
5. Read `as-built\isl-context-strategy-reconciliation.md`.
6. Continue at the current execution point.
