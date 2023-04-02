﻿using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Database.Arboretum;
using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSubstitute;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Services;

public class SpecieServiceTests
{
    private readonly Specie _specieStrelitzia;
    private readonly DbContextOptions<ArboretumContext> _inMemoryOptions;

    public SpecieServiceTests()
    {
        _specieStrelitzia = new Specie
        {
            Id = 1,
            Genus = "Strelitzia",
            Species = "Reginae",
            Cultivar = "",
            CommonNames = "Bird of paradise,Paradijsvogelbloem",
            Description = "some text.",
            PlantType = ObjectTypeExamples.SmallShrub,
            Cycle = Lifecycle.Perennial
        };
        _inMemoryOptions = new DbContextOptionsBuilder<ArboretumContext>()
            .UseInMemoryDatabase(databaseName: "specieDb")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
    }

    /*[Fact(Skip = "Not properly working")]
    public async Task UpdateSpecie_CallsContextUpdate()
    {
        /*var context = Substitute.For<IArboretumContext>();
        context.Species.Add(_specieStrelitzia);#1#
        var specieService = new SpecieService(null);
        var updatedSpecieStrelitzia = new Specie
        {
            Id = 1,
            Genus = "Strelitzia1",
            Species = "Reginae1",
            Cultivar = "1",
            CommonNames = "Bird of paradise,Paradijsvogelbloem1",
            Description = "some text.1",
            PlantType = ObjectTypeExamples.SmallShrub,
            Cycle = Lifecycle.Biennial
        };
        
        await specieService.Update(updatedSpecieStrelitzia);

        var storedSpecie = context.Species.FirstOrDefault(specie => specie.Id == _specieStrelitzia.Id);
        AssertObjects.AssertSpecie(updatedSpecieStrelitzia, storedSpecie);
    }*/

    
}