# Sagex.Engine Local Runbook

Status: Non-normative local operation notes.

## Resume Point

Check:

`as-built/implementation-progress.md`

## Build

```powershell
dotnet build Sagex.Engine.slnx
```

## Test

```powershell
dotnet test Sagex.Engine.slnx
```

## Current Foundation

The local foundation includes:

- .NET 10 solution and projects
- imported Sage-X platform schema
- schema loader
- schema definition index
- JSON Schema validator wrapper
- valid and invalid fixture convention
- fixture discovery contract tests

## Normative Source

The normative specifications remain in:

`C:\Users\esobr\source\repos\Imhotep.Specifications\specs`
