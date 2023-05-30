using Greenmaster.AdminPortal.Controllers;

namespace Greenmaster.AdminPortal.Tests.Controllers.Rendering;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new RenderingController(null!));
    }
}