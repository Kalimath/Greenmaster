﻿using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Tests.Factories.Base;

namespace Greenmaster.Core.Tests.Factories.GardenStyleFactoryTests;

public class CreateGardenStyleShould : GardenStyleFactoryTestBase
{

    [Fact]
    public async Task ThrowArgumentNullException_WhenGardenStyleViewModelIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => GardenStyleFactory.Create(null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ThrowArgumentException_WhenNameInvalid(string name)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Name = name;

        await Assert.ThrowsAsync<ArgumentException>(() => GardenStyleFactory.Create(gardenStyleViewModel));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ThrowArgumentException_WhenDescriptionInvalid(string description)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Description = description;

        await Assert.ThrowsAsync<ArgumentException>(() => GardenStyleFactory.Create(gardenStyleViewModel));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public async Task ThrowArgumentOutOfRangeException_WhenIdInvalid(int id)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Id = id;

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => GardenStyleFactory.Create(gardenStyleViewModel));
    }

    [Fact]
    public void SetId_WhenValid()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Id, gardenStyle.Id);
    }

    [Fact]
    public async Task SetPathSize_WhenValid()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.PathSize, gardenStyle.PathSize);
    }

    [Fact]
    public async Task SetMaterials_WhenValid()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Materials, gardenStyle.Materials);
    }

    [Fact]
    public async Task SetName_WhenValid()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Name, gardenStyle.Name);
    }

    [Fact]
    public async Task SetDescription_WhenValid()
    {
        if (GardenStyleFactory != null)
        {
            var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);

            Assert.NotNull(gardenStyle);
            Assert.Equal(GardenStyleViewModel.Description, gardenStyle.Description);
        }
    }

    [Fact]
    public async Task SetColors_WhenPresent()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Colors, gardenStyle.Colors);
    }

    [Fact]
    public async Task SetConcepts_WhenPresent()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Concepts, gardenStyle.Concepts);
    }

    [Fact]
    public async Task SetShapes_WhenPresent()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Shapes, gardenStyle.Shapes);
    }
    
    // test that checks that AllSeasonInterest is set correctly
    [Fact]
    public async Task SetAllSeasonInterest_WhenPresent()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.AllSeasonInterest, gardenStyle.AllSeasonInterest);
    }

    [Fact]
    public async Task SetRequiresLargeGarden()
    {
        var gardenStyle = await GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.RequiresLargeGarden, gardenStyle.RequiresLargeGarden);
    }
}