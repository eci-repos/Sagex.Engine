# Sagex.Engine Implementation Decisions

Status: Non-normative implementation decision log.

## Decisions

| Date | Decision | Reason |
| --- | --- | --- |
| 2026-06-19 | Use .NET 10 and C# for the initial implementation. | Matches the agreed development baseline. |
| 2026-06-19 | Use `Sagex.Engine.slnx` as the Visual Studio solution format. | Aligns with current .NET solution support and the requested solution location. |
| 2026-06-19 | Keep `Sagex.Engine` as a sibling project to `Imhotep.Specifications`. | Keeps implementation artifacts separate from normative specification assets. |
| 2026-06-19 | Import an implementation copy of the Sage-X platform schema under `schemas/platform`. | Allows local implementation/testing while preserving the normative source in `Imhotep.Specifications`. |
| 2026-06-19 | Use `System.Text.Json` for schema/artifact JSON parsing. | Matches the agreed serialization baseline. |
| 2026-06-19 | Use `JsonSchema.Net` for JSON Schema validation. | Matches the JSON Schema.NET-style validation direction. |
| 2026-06-19 | Use `fixtures/{valid|invalid}/{schema-definition-name}/{fixture-name}.json`. | Makes fixture intent and schema mapping discoverable by path. |
| 2026-06-19 | Keep as-built records non-normative. | Prevents implementation progress from being mistaken for Sage-X specification requirements. |
| 2026-06-21 | Treat local milestones as ISL Construction Boundaries and context packs as minimized Connection Contexts. | Reconciles the local-agent scarce-context strategy with ISL r2 instead of creating a parallel continuation model. |
| 2026-06-21 | Make local Ollama guidance profile-based with `sagex` and `sagex-isl` context profiles. | Keeps Sage-X core work specification-agnostic and only loads ISL context for ISL plugin or bridge tasks. |
| 2026-06-21 | Run local Ollama packet work on per-packet Git branches by default. | Makes local-agent experiments reviewable and easy to abandon before acceptance. |
| 2026-06-21 | Record local-agent attempts in `as-built/local-agent-runs.md` and review them with an operator checklist. | Preserves acceptance/rejection evidence for local autonomous construction attempts. |
| 2026-06-21 | Provide a patch-application helper that checks a saved patch before applying and then runs tests/build. | Keeps local-agent patch acceptance deterministic and reversible before commit. |
