namespace Sagex.Engine.Tests;

public sealed class SolutionSmokeTests
{
    [Fact]
    public void TestAssemblyLoads()
    {
        Assert.Equal("Sagex.Engine.Tests", typeof(SolutionSmokeTests).Assembly.GetName().Name);
    }
}
