using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPlantServiceIsNull()
    {
        // Arrange
        PlaceableController Act() => new (null!, Substitute.For<IModelFactory<Core.Models.Placeables.Placeable, PlaceableViewModel>>());
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(Act);
    }
    [Fact]
    public void ThrowArgumentNullException_WhenPlaceableFactoryIsNull()
    {
        // Arrange
        PlaceableController Act() => new (Substitute.For<IPlantService>(), null!);
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(Act);
    }
}