using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models.ViewModels;

namespace Greenmaster.AdminPortal.Tests.Controllers.Rendering;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new RenderingController(null!, Substitute.For<IViewModelMapper<Core.Models.Rendering, RenderingViewModel>>()));
    }
}