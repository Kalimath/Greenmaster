using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Type;

namespace Greenmaster.AdminPortal.Tests.Controllers.Specie;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new SpecieController(null!,
            Substitute.For<IObjectTypeService<PlantType>>(),
            Substitute.For<IViewModelMapper<Core.Models.Specie, SpecieViewModel>>()));
    }
}