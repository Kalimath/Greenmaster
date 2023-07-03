using Greenmaster.Core.Examples;
using Greenmaster.Core.Models;
using Greenmaster.Core.Services.Specie;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public class CreatePlantShould : PlaceableControllerTestBase
{
    private static readonly List<PlantType> SomePlantTypes;
    private static readonly List<Core.Models.Specie> SomeSpecies;

    static CreatePlantShould()
    {
        SomePlantTypes = new List<PlantType>(ExamplesService.GetAllPlantTypes());
        SomeSpecies = new List<Core.Models.Specie>(SpecieExamples.GetAll());
        
        PlantTypeService.GetAll().Returns(SomePlantTypes);
        SpecieService.GetAll().Returns(SomeSpecies);
    }

    [Fact]
    public async Task ReturnView()
    {
        var viewResult = await PlaceableController.CreatePlant();
        
        Assert.NotNull(viewResult);
        Assert.IsType<ViewResult>(viewResult);
    }
    
    [Fact]
    public async Task CallPlantTypeService()
    {
        _ = PlaceableController.CreatePlant();
        
        await PlantTypeService.Received().GetAll();
    }
    
    [Fact]
    public async Task CallSpecieService()
    {
        _ = PlaceableController.CreatePlant();
        
        await SpecieService.Received().GetAll();
    }

    [Fact]
    public async Task ReturnViewResult_WithViewData_ContainingPlantTypes()
    {
        var viewResult = await PlaceableController.CreatePlant();
        
        Assert.NotNull(viewResult);
        Assert.True(((ViewResult)viewResult).ViewData.ContainsKey("PlantTypes"));
    }

    [Fact]
    public async Task ReturnViewResult_WithViewData_ContainingSpecies()
    {
        var viewResult = await PlaceableController.CreatePlant();
        
        Assert.NotNull(viewResult);
        Assert.True(((ViewResult)viewResult).ViewData.ContainsKey("Species"));
    }
    
}