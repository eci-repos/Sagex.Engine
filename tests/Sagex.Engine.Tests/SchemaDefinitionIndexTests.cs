using System.Text.Json;
using Sagex.Engine.Schemas;

namespace Sagex.Engine.Tests;

public sealed class SchemaDefinitionIndexTests
{
    [Theory]
    [InlineData("executionPlan")]
    [InlineData("knowledgeUnit")]
    [InlineData("artifactManifest")]
    public async Task FromDocumentResolvesRequiredDefinitions(string definitionName)
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();

        SchemaDefinitionIndex index = SchemaDefinitionIndex.FromDocument(schema);

        Assert.True(index.ContainsDefinition(definitionName));
        Assert.Equal(JsonValueKind.Object, index.GetDefinition(definitionName).ValueKind);
    }

    [Fact]
    public async Task FromDocumentExposesStableDefinitionNames()
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();

        SchemaDefinitionIndex index = SchemaDefinitionIndex.FromDocument(schema);

        Assert.Equal(schema.DefinitionCount, index.Count);
        Assert.Contains("executionPlan", index.DefinitionNames);
        Assert.Equal(index.DefinitionNames.Order(StringComparer.Ordinal), index.DefinitionNames);
    }

    [Fact]
    public async Task GetDefinitionRejectsUnknownDefinitionName()
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();
        SchemaDefinitionIndex index = SchemaDefinitionIndex.FromDocument(schema);

        KeyNotFoundException exception = Assert.Throws<KeyNotFoundException>(
            () => index.GetDefinition("missingDefinition"));

        Assert.Contains("missingDefinition", exception.Message, StringComparison.Ordinal);
    }

    private static ValueTask<PlatformSchemaDocument> LoadPlatformSchemaAsync()
    {
        string schemaPath = TestRepositoryPaths.GetRepositoryPath(
            "schemas",
            "platform",
            "sagex.00.v1r0.platform-schema.json");

        return PlatformSchemaLoader.LoadAsync(schemaPath);
    }
}
