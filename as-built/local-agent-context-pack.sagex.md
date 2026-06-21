# Sagex.Engine Local Agent Context Pack

Status: Non-normative condensed operating brief for local agents.

This file is a compact working context. It does not replace the normative Sage-X, ISL, or bridge specifications. When there is conflict, the normative files in `Imhotep.Specifications` control.

## Current State

Project root:

`C:\Users\esobr\source\repos\Sagex.Engine`

Normative specification root:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs`

Milestone `M0: Local Takeover-Ready Sagex.Engine Foundation` is complete.

Current execution point:

`WP-0101.1: Define ISL plugin registration fixture`

## Operating Rules

- Build schema-first. Every module, fixture, service, adapter, or test should map to a Sage-X platform schema artifact or be explicitly treated as internal implementation detail.
- Keep implementation local-first and modular.
- Preserve traceability from implementation work to specification files, schema definitions, fixtures, and work packets.
- Do not silently change Sage-X or ISL semantics in code.
- Reuse before construction. Search for existing Sage-X assets before building overlapping functionality.
- Keep Sage-X execution mechanics separate from ISL construction semantics.
- Keep as-built records non-normative.
- Update `as-built/implementation-progress.md` after every completed work packet.
- Record meaningful implementation choices in `as-built/implementation-decisions.md`.
- Run build and tests before marking a packet complete.

## Source Map

Primary implementation plan:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\implementation planning\SAGE-X to ISL Implementation Plan.md`

Execution plan:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\implementation planning\sagex-to-isl.implementation.execution-plan.json`

Task graph:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\implementation planning\sagex-to-isl.implementation-task-graph.json`

Bridge profile:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\integration profiles\ISL-SageX Integration Profile.md`

Discussion baseline:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\discussion logs\discussion-2026-06-18.md`

ISL context strategy reconciliation:

`C:\Users\esobr\source\repos\Sagex.Engine\as-built\isl-context-strategy-reconciliation.md`

Normative Sage-X v1r0 folder:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\sage-x releases\sagex v1r0`

Primary platform schema source:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs\sage-x releases\sagex v1r0\sagex.00.v1r0.platform-schema.json`

Implementation schema copy:

`C:\Users\esobr\source\repos\Sagex.Engine\schemas\platform\sagex.00.v1r0.platform-schema.json`

## Sage-X v1r0 File Map

- `sagex.00.v1r0.platform-schema.json`: consolidated schema bundle for platform artifacts and implementation planning artifacts.
- `sagex.00.v1r0.api-schema.json`: API/control surface schema.
- `sagex.00.v1r0.architecture.md`: platform architecture.
- `sagex.01.v1r0.execution-state-machine.md`: execution state behavior.
- `sagex.02.v1r0.trace-observability.md`: trace and observability behavior.
- `sagex.04.v1r0.execution-api-control-surface.md`: external execution, planning, governance, and observability interfaces.
- `sagex.05.v1r0.system-assembly.md`: integrated system assembly model.
- `sagex.06.v1r0.certification-conformance.md`: conformance expectations.
- `sagex.07.v1r0.reference-implementation-blueprint.md`: logical implementation modules.
- `sagex.08.v1r0.specification-plugin-interface.md`: external specification language integration.
- `sagex.09.v1r0.capability-registry.md`: capability registration, discovery, and invocation.
- `sagex.10.v1r0.security-model.md`: execution security and isolation.
- `sagex.11.v1r0.failure.and.recovery.model.md`: failure records, rollback, branch, and recovery.
- `sagex.12.v1r0.governance-model.md`: policy, approval, override, and enforcement behavior.
- `sagex.13.v1r0.deployment-architecture.md`: runtime deployment and process boundaries.
- `sagex.14.v1r0.observability-model.md`: execution trace and telemetry evidence.
- `sagex.15.v1r0.tech-stack.md`: technology stack guidance.

## M0 Foundation Already Built

Solution:

`C:\Users\esobr\source\repos\Sagex.Engine\Sagex.Engine.slnx`

Projects:

- `src\Sagex.Engine.Core`
- `src\Sagex.Engine.Schemas`
- `src\Sagex.Engine.Validation`
- `src\Sagex.Engine.Console`
- `tests\Sagex.Engine.Tests`

Implemented:

- .NET 10 solution and module skeleton.
- shared build settings in `Directory.Build.props`.
- local implementation copy of Sage-X platform schema.
- `PlatformSchemaLoader` using `System.Text.Json`.
- `PlatformSchemaDocument`.
- `SchemaDefinitionIndex` for named schema definitions.
- `JsonArtifactValidator` using `JsonSchema.Net`.
- fixture convention: `fixtures/{valid|invalid}/{schema-definition-name}/{fixture-name}.json`.
- first valid fixture: `fixtures\valid\artifactManifest\minimal.json`.
- first invalid fixture: `fixtures\invalid\artifactManifest\missing-required-fields.json`.
- fixture discovery contract tests.
- local runbook: `as-built\local-runbook.md`.

Latest known validation:

- `dotnet test Sagex.Engine.slnx`: passed, 21 tests.
- `dotnet build Sagex.Engine.slnx`: passed, 0 warnings, 0 errors.

## Phase 0 Completion

Phase 0 is complete:

- `WP-0001`: repository/module skeleton.
- `WP-0002`: platform schema loader.
- `WP-0003`: schema definition index.
- `WP-0004`: validation by schema definition name.
- `WP-0005`: fixture directory and naming convention.
- `WP-0006`: first artifact manifest fixture.
- `WP-0007`: contract test harness.

## Next Work: Phase 1

Next packet:

`WP-0101.1: Define ISL plugin registration fixture`

Purpose:

Create the first fixture for an ISL specification plugin registration. It should validate against the Sage-X platform schema definition:

`specificationPluginRegistration`

Likely fixture location:

`fixtures\valid\specificationPluginRegistration\isl-plugin-registration.json`

Expected approach:

1. Inspect the `specificationPluginRegistration` definition in the platform schema.
2. Create the minimal valid fixture using exact required fields.
3. Let the fixture discovery harness validate it automatically.
4. Add an invalid fixture only if needed for the work packet scope.
5. Run `dotnet test Sagex.Engine.slnx`.
6. Run `dotnet build Sagex.Engine.slnx`.
7. Update `as-built\implementation-progress.md`.

## Phase 1 Direction

Phase 1 goal:

Implement the first ISL-compatible specification ingestion path.

Near-term packets:

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

Do not run build and test in parallel against the same output folders; it can create transient file locks.

## Drift Warnings

Flag drift if local work:

- changes Sage-X platform schema semantics without a specification update.
- treats as-built notes as normative requirements.
- hardcodes ISL semantics into generic Sage-X execution mechanics.
- skips fixture-backed validation for schema-backed artifacts.
- creates broad tasks that do not map to a work packet.
- loses source traceability to specs, schema definitions, or work packets.
- bypasses build/test validation before marking progress complete.
- mixes generated implementation behavior into normative specification files.

## Fast Resume Checklist

1. Read this file.
2. Read `as-built\implementation-progress.md`.
3. Read `as-built\implementation-decisions.md`.
4. Read `as-built\isl-context-strategy-reconciliation.md`.
5. Confirm `dotnet test Sagex.Engine.slnx` passes.
6. Continue at the current execution point.
