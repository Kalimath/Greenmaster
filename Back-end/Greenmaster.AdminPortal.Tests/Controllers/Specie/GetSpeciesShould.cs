using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Examples;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Specie;
using Greenmaster.Core.Services.Type;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.AdminPortal.Tests.Controllers.Specie;

public class GetSpeciesShould
{
    [Fact]
    public async Task ReturnJsonResult_WhenCalled()
    {
        var specieService = Substitute.For<ISpecieService>();
        var plantTypeService = Substitute.For<IObjectTypeService<PlantType>>();
        var specieFactory = Substitute.For<IModelFactory<Core.Models.Specie, SpecieViewModel>>();
        var specieController = new SpecieController(specieService, plantTypeService, specieFactory);
        specieService.GetAll().ReturnsForAnyArgs(SpecieExamples.GetAll());

        var result = await specieController.GetSpecies();
        
        Assert.NotNull(result);
        Assert.IsType<JsonResult>(result);
    }
    /*[Fact]
    public async Task ReturnAllSpecies_WhenCalled()
    {
        var specieService = Substitute.For<ISpecieService>();
        var specieController = new SpecieController(specieService);
        specieService.GetSpecies().ReturnsForAnyArgs(SpecieExamples.GetAll());

        var result = await specieController.GetSpecies();
        Assert.NotNull(result);
        var specieViewModels = ((List<Models.Specie>)result.Value);
        Assert.NotNull(specieViewModels);
    }*/
}