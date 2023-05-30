using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Services.Type;

namespace Greenmaster.AdminPortal.Tests.Controllers.Specie;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new SpecieController(null!, Substitute.For<IObjectTypeService<PlantType>>()));
    }
}