using Sagex.Engine.Schemas;
using Sagex.Engine.Validation;

namespace Sagex.Engine.Tests;

public sealed class JsonArtifactValidatorTests
{
    [Fact]
    public async Task ValidateAcceptsValidArtifactManifestFixture()
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();
        string artifactJson = await File.ReadAllTextAsync(
            TestRepositoryPaths.GetRepositoryPath(
                "fixtures",
                "valid",
                "artifactManifest",
                "minimal.json"));

        ArtifactValidationResult result = JsonArtifactValidator.Validate(
            schema,
            "artifactManifest",
            artifactJson);

        Assert.True(result.IsValid, result.EvaluationJson);
        Assert.Equal("artifactManifest", result.DefinitionName);
        Assert.Contains("\"valid\":true", result.EvaluationJson, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task ValidateRejectsInvalidArtifactManifest()
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();
        ArtifactValidationResult result = JsonArtifactValidator.Validate(
            schema,
            "artifactManifest",
            """
            {
              "manifest_id": "MAN-test-0001"
            }
            """);

        Assert.False(result.IsValid);
        Assert.Equal("artifactManifest", result.DefinitionName);
    }

    [Fact]
    public async Task ValidateRejectsUnknownDefinitionName()
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();
        Assert.Throws<KeyNotFoundException>(
            () => JsonArtifactValidator.Validate(schema, "missingDefinition", "{}"));
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
