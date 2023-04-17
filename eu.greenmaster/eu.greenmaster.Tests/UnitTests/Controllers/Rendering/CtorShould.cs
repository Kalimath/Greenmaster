using eu.greenmaster.ManagerApp.Controllers;

namespace eu.greenmaster.Tests.UnitTests.Controllers.Rendering;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new RenderingController(null!));
    }
}