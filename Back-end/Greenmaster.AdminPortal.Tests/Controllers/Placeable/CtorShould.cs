using Greenmaster.AdminPortal.Controllers;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public class CtorShould : PlaceableControllerTestBase
{
    [Fact]
    public void ThrowArgumentNullException_WhenPlantServiceIsNull()
    {
        // Arrange
        PlaceableController Act() => new (null!, SpecieService, PlaceableMapper);
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(Act);
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieServiceIsNull()
    {
        // Arrange
        PlaceableController Act() => new (PlantService, null!, PlaceableMapper);
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(Act);
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenPlaceableFactoryIsNull()
    {
        // Arrange
        PlaceableController Act() => new (PlantService, SpecieService, null!);
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(Act);
    }
}