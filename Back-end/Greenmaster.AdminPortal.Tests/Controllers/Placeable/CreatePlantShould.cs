using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public class CreatePlantShould : PlaceableControllerTestBase
{
    private static readonly List<Core.Models.Specie> SomeSpecies;

    static CreatePlantShould()
    {
        SomeSpecies = new List<Core.Models.Specie>(ExamplesService.GetAllSpecies());
        
        //Substitutes
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
    public async Task CallSpecieService()
    {
        _ = PlaceableController.CreatePlant();
        
        await SpecieService.Received().GetAll();
    }

    [Fact]
    public async Task ReturnViewResult_WithViewData_ContainingSpecies()
    {
        var viewResult = await PlaceableController.CreatePlant();
        
        Assert.NotNull(viewResult);
        Assert.True(((ViewResult)viewResult).ViewData.ContainsKey("Species"));
    }
    
}