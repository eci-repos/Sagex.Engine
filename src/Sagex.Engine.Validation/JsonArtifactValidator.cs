using System.Text.Json;
using Json.Schema;
using Sagex.Engine.Schemas;

namespace Sagex.Engine.Validation;

public static class JsonArtifactValidator
{
    private const string Draft07SchemaUri = "http://json-schema.org/draft-07/schema#";

    public static ArtifactValidationResult Validate(
        PlatformSchemaDocument platformSchema,
        string definitionName,
        string artifactJson)
    {
        ArgumentNullException.ThrowIfNull(platformSchema);
        ArgumentException.ThrowIfNullOrWhiteSpace(definitionName);
        ArgumentException.ThrowIfNullOrWhiteSpace(artifactJson);

        JsonSchema schema = BuildSchemaForDefinition(platformSchema, definitionName);

        using JsonDocument artifact = JsonDocument.Parse(artifactJson);
        EvaluationResults evaluation = schema.Evaluate(artifact.RootElement);
        string evaluationJson = JsonSerializer.Serialize(evaluation);

        return new ArtifactValidationResult(definitionName, evaluation.IsValid, evaluationJson);
    }

    private static JsonSchema BuildSchemaForDefinition(
        PlatformSchemaDocument platformSchema,
        string definitionName)
    {
        SchemaDefinitionIndex index = SchemaDefinitionIndex.FromDocument(platformSchema);
        _ = index.GetDefinition(definitionName);

        JsonElement definitions = platformSchema.Root.GetProperty("definitions");
        string escapedDefinitionName = EscapeJsonPointerSegment(definitionName);

        string schemaJson = $$"""
            {
              "$schema": "{{Draft07SchemaUri}}",
              "$ref": "#/definitions/{{escapedDefinitionName}}",
              "definitions": {{definitions.GetRawText()}}
            }
            """;

        return JsonSchema.FromText(schemaJson);
    }

    private static string EscapeJsonPointerSegment(string value) =>
        value.Replace("~", "~0", StringComparison.Ordinal).Replace("/", "~1", StringComparison.Ordinal);
}
