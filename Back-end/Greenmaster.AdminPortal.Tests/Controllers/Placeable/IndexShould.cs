using Greenmaster.Core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public class IndexShould : PlaceableControllerTestBase
{
    [Fact]
    public async Task CallPlantService()
    {
        _ = await PlaceableController.Index();
        
        await PlantService.Received(1).GetAll();
    }
    
    [Fact]
    public async Task ReturnEmptyList_WhenPlantServiceReturnsNull()
    {
        var result = await PlaceableController.Index();
        
        Assert.Empty((((ViewResult)result).Model as List<PlaceableViewModel>)!);
    }

    [Fact]
    public async Task ReturnAll_IfPresent()
    {
        // Arrange
        PlantService.GetAll().Returns(SomePlants);
        
        // Act
        var result = await PlaceableController.Index();
        
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task ReturnType_IsViewResult()
    {
        // Act
        var result = await PlaceableController.Index();
        
        Assert.NotNull(result);
        Assert.IsType<ViewResult>(result);
    }
    
    [Fact]
    public async Task ReturnModel_WithTypePlaceableViewModel()
    {
        // Arrange
        PlantService.GetAll().Returns(SomePlants);
        
        // Act
        var result = (ViewResult)await PlaceableController.Index();
        
        Assert.NotNull(result);
        Assert.IsType<List<PlaceableViewModel>>(result.Model);
    }
    
    [Fact]
    public async Task Return_WithPlaceableViewModel_ContainsPlants()
    {
        // Arrange
        PlantService.GetAll().Returns(SomePlants);
        
        // Act
        var result = (ViewResult)await PlaceableController.Index();
        
        Assert.NotNull(result);
        Assert.True(SomePlants.Count == ((List<PlaceableViewModel>)result.Model!).Count);
    }
}