namespace Sagex.Engine.Tests;

internal static class TestRepositoryPaths
{
    public static string GetRepositoryPath(params string[] segments)
    {
        DirectoryInfo? current = new(AppContext.BaseDirectory);

        while (current is not null && !File.Exists(Path.Combine(current.FullName, "Sagex.Engine.slnx")))
        {
            current = current.Parent;
        }

        Assert.NotNull(current);

        return Path.Combine([current.FullName, .. segments]);
    }
}
