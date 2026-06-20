using Sagex.Engine.Schemas;

namespace Sagex.Engine.Tests;

public sealed class PlatformSchemaLoaderTests
{
    [Fact]
    public async Task LoadAsyncReadsImportedPlatformSchema()
    {
        string schemaPath = TestRepositoryPaths.GetRepositoryPath(
            "schemas",
            "platform",
            "sagex.00.v1r0.platform-schema.json");

        using PlatformSchemaDocument schema = await PlatformSchemaLoader.LoadAsync(schemaPath);

        Assert.Equal(Path.GetFullPath(schemaPath), schema.SourcePath);
        Assert.Equal("https://sage-x.local/schemas/sagex.00.v1r0.platform-schema.json", schema.SchemaId);
        Assert.Equal("SAGE-X Platform Schema", schema.Title);
        Assert.True(schema.DefinitionCount > 0);
    }

    [Fact]
    public async Task LoadAsyncRejectsMissingSchemaFile()
    {
        string missingPath = TestRepositoryPaths.GetRepositoryPath("schemas", "platform", "missing.schema.json");

        FileNotFoundException exception =
            await Assert.ThrowsAsync<FileNotFoundException>(() => PlatformSchemaLoader.LoadAsync(missingPath).AsTask());

        Assert.Equal(Path.GetFullPath(missingPath), exception.FileName);
    }

}
