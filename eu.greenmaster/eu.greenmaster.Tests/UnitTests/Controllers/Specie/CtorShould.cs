using eu.greenmaster.ManagerApp.Controllers;
using eu.greenmaster.Models;
using eu.greenmaster.Repository.Services.Type;
using NSubstitute;

namespace eu.greenmaster.Tests.UnitTests.Controllers.Specie;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new SpecieController(null!, Substitute.For<IObjectTypeService<PlantType>>()));
    }
}