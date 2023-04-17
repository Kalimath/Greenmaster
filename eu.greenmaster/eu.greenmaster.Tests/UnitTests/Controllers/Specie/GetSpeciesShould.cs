using eu.greenmaster.EFCore.Services;
using eu.greenmaster.Examples;
using eu.greenmaster.ManagerApp.Controllers;
using eu.greenmaster.Models;
using eu.greenmaster.Repository.Services.Specie;
using eu.greenmaster.Repository.Services.Type;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace eu.greenmaster.Tests.UnitTests.Controllers.Specie;

public class GetSpeciesShould
{
    [Fact]
    public async Task ReturnJsonResult_WhenCalled()
    {
        var specieService = Substitute.For<ISpecieService>();
        var plantTypeService = Substitute.For<IObjectTypeService<PlantType>>();
        var specieController = new SpecieController(specieService, plantTypeService);
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