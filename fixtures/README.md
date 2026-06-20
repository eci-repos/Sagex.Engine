# Fixtures

Fixtures are schema validation examples for Sagex.Engine contract tests.

## Convention

Fixture files use this path shape:

`fixtures/{valid|invalid}/{schema-definition-name}/{fixture-name}.json`

Examples:

`fixtures/valid/artifactManifest/minimal.json`

`fixtures/invalid/artifactManifest/missing-required-fields.json`

The `{schema-definition-name}` segment must match a definition name from the Sage-X platform schema exactly.

Valid fixtures are expected to pass validation. Invalid fixtures are expected to fail validation.
