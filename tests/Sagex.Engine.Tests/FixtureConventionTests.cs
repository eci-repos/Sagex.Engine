namespace Sagex.Engine.Tests;

public sealed class FixtureConventionTests
{
    [Theory]
    [InlineData("fixtures")]
    [InlineData("fixtures", "valid")]
    [InlineData("fixtures", "invalid")]
    [InlineData("fixtures", "valid", "artifactManifest")]
    [InlineData("fixtures", "invalid", "artifactManifest")]
    public void ExpectedFixtureConventionDirectoriesExist(params string[] segments)
    {
        string path = TestRepositoryPaths.GetRepositoryPath(segments);

        Assert.True(Directory.Exists(path), $"Expected fixture directory was not found: {path}");
    }

    [Fact]
    public void FixtureConventionReadmeExists()
    {
        string path = TestRepositoryPaths.GetRepositoryPath("fixtures", "README.md");

        Assert.True(File.Exists(path), $"Expected fixture convention README was not found: {path}");
    }
}
