using Greenmaster.Core.Factories;
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
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SetAllSeasonInterest_WhenPresent(bool allSeasonInterest)  
    {
        var gardenStyleVmWithAllSeasonInterest = GardenStyleViewModel.Clone();
        gardenStyleVmWithAllSeasonInterest.AllSeasonInterest = allSeasonInterest;
        
        var gardenStyle = await GardenStyleFactory.Create(gardenStyleVmWithAllSeasonInterest);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(allSeasonInterest, gardenStyle.AllSeasonInterest);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SetRequiresLargeGarden(bool requiresLargeGarden)
    {
        var gardenStyleVmForLargeGardens = GardenStyleViewModel.Clone();
        gardenStyleVmForLargeGardens.RequiresLargeGarden = requiresLargeGarden;
        
        var gardenStyle = await GardenStyleFactory.Create(gardenStyleVmForLargeGardens);

        Assert.NotNull(gardenStyle);
        Assert.Equal(requiresLargeGarden, gardenStyle.RequiresLargeGarden);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SetDivideIntoRooms(bool divideIntoRooms)
    {
        var gardenStyleVmDividedIntoRooms = GardenStyleViewModel.Clone();
        gardenStyleVmDividedIntoRooms.DivideIntoRooms = divideIntoRooms;
        
        var gardenStyle = await GardenStyleFactory.Create(gardenStyleVmDividedIntoRooms);

        Assert.NotNull(gardenStyle);
        Assert.Equal(divideIntoRooms, gardenStyle.DivideIntoRooms);
    }
}