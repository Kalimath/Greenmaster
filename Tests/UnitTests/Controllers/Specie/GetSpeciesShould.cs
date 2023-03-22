using Greenmaster_ASP.Controllers;
using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;
using SpecieExamples = Greenmaster_ASP.Models.Examples.SpecieExamples;

namespace Greenmaster_ASP.Tests.UnitTests.Controllers.Specie;

public class GetSpeciesShould
{
    [Fact]
    public async Task ReturnJsonResult_WhenCalled()
    {
        var specieService = Substitute.For<ISpecieService>();
        var specieController = new SpecieController(specieService);
        specieService.GetSpecies().ReturnsForAnyArgs(SpecieExamples.GetAll());

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