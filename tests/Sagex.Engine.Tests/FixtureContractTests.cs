using Sagex.Engine.Schemas;
using Sagex.Engine.Validation;

namespace Sagex.Engine.Tests;

public sealed class FixtureContractTests
{
    [Fact]
    public void ValidFixtureDiscoveryFindsJsonFiles()
    {
        Assert.NotEmpty(DiscoverFixtures("valid"));
    }

    [Fact]
    public void InvalidFixtureDiscoveryFindsJsonFiles()
    {
        Assert.NotEmpty(DiscoverFixtures("invalid"));
    }

    [Theory]
    [MemberData(nameof(ValidFixtures))]
    public async Task ValidFixturesPassSchemaValidation(FixtureCase fixture)
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();
        string artifactJson = await File.ReadAllTextAsync(fixture.Path);

        ArtifactValidationResult result = JsonArtifactValidator.Validate(
            schema,
            fixture.DefinitionName,
            artifactJson);

        Assert.True(result.IsValid, $"{fixture.Path}{Environment.NewLine}{result.EvaluationJson}");
    }

    [Theory]
    [MemberData(nameof(InvalidFixtures))]
    public async Task InvalidFixturesFailSchemaValidation(FixtureCase fixture)
    {
        using PlatformSchemaDocument schema = await LoadPlatformSchemaAsync();
        string artifactJson = await File.ReadAllTextAsync(fixture.Path);

        ArtifactValidationResult result = JsonArtifactValidator.Validate(
            schema,
            fixture.DefinitionName,
            artifactJson);

        Assert.False(result.IsValid);
    }

    public static IEnumerable<object[]> ValidFixtures() =>
        DiscoverFixtures("valid").Select(fixture => new object[] { fixture });

    public static IEnumerable<object[]> InvalidFixtures() =>
        DiscoverFixtures("invalid").Select(fixture => new object[] { fixture });

    private static FixtureCase[] DiscoverFixtures(string validity)
    {
        string root = TestRepositoryPaths.GetRepositoryPath("fixtures", validity);

        return Directory
            .EnumerateFiles(root, "*.json", SearchOption.AllDirectories)
            .Select(path => ToFixtureCase(root, path))
            .OrderBy(fixture => fixture.Path, StringComparer.Ordinal)
            .ToArray();
    }

    private static FixtureCase ToFixtureCase(string root, string path)
    {
        string relativePath = Path.GetRelativePath(root, path);
        string[] segments = relativePath.Split(
            [Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar],
            StringSplitOptions.RemoveEmptyEntries);

        Assert.True(segments.Length >= 2, $"Fixture path must include schema definition folder: {path}");

        return new FixtureCase(segments[0], path);
    }

    private static ValueTask<PlatformSchemaDocument> LoadPlatformSchemaAsync()
    {
        string schemaPath = TestRepositoryPaths.GetRepositoryPath(
            "schemas",
            "platform",
            "sagex.00.v1r0.platform-schema.json");

        return PlatformSchemaLoader.LoadAsync(schemaPath);
    }

    public sealed record FixtureCase(string DefinitionName, string Path)
    {
        public override string ToString() => $"{DefinitionName}: {System.IO.Path.GetFileName(Path)}";
    }
}
