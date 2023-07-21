using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Tests.Mappers.Base;
using StaticData.Taxonomy;

namespace Greenmaster.Core.Tests.Mappers.GardenStyleMapperTests;

public class ToModelShould : GardenStyleMapperTestBase
{

    [Fact]
    public async Task ThrowArgumentNullException_WhenGardenStyleViewModelIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => GardenStyleMapper.ToModel(null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ThrowArgumentException_WhenNameInvalid(string name)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Name = name;

        await Assert.ThrowsAsync<ArgumentException>(() => GardenStyleMapper.ToModel(gardenStyleViewModel));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ThrowArgumentException_WhenDescriptionInvalid(string description)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Description = description;

        await Assert.ThrowsAsync<ArgumentException>(() => GardenStyleMapper.ToModel(gardenStyleViewModel));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public async Task ThrowArgumentOutOfRangeException_WhenIdInvalid(int id)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Id = id;

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => GardenStyleMapper.ToModel(gardenStyleViewModel));
    }

    [Fact]
    public void SetId_WhenValid()
    {
        var gardenStyle = GardenStyleMapper.ToModel(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Id, gardenStyle.Id);
    }

    [Fact]
    public async Task SetPathSize_WhenValid()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.PathSize, gardenStyle.PathSize);
    }

    [Fact]
    public async Task SetMaterials_WhenValid()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Materials, gardenStyle.Materials);
    }

    [Fact]
    public async Task SetName_WhenValid()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Name, gardenStyle.Name);
    }

    [Fact]
    public async Task SetDescription_WhenValid()
    {
        if (GardenStyleMapper != null)
        {
            var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);

            Assert.NotNull(gardenStyle);
            Assert.Equal(GardenStyleViewModel.Description, gardenStyle.Description);
        }
    }

    [Fact]
    public async Task SetColors_WhenPresent()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Colors, gardenStyle.Colors);
    }

    [Fact]
    public async Task SetConcepts_WhenPresent()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Concepts, gardenStyle.Concepts);
    }

    [Fact]
    public async Task SetShapes_WhenPresent()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);

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
        
        var gardenStyle = await GardenStyleMapper.ToModel(gardenStyleVmWithAllSeasonInterest);
        
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
        
        var gardenStyle = await GardenStyleMapper.ToModel(gardenStyleVmForLargeGardens);

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
        
        var gardenStyle = await GardenStyleMapper.ToModel(gardenStyleVmDividedIntoRooms);

        Assert.NotNull(gardenStyle);
        Assert.Equal(divideIntoRooms, gardenStyle.DivideIntoRooms);
    }
    
    [Fact]
    public async Task SetSuitablePlantGenera_WhenValid()
    {
        var gardenStyle = await GardenStyleMapper.ToModel(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.SuitablePlantGenera, gardenStyle.SuitablePlantGenera);
    }
    
    [Fact]
    public async Task ReturnEmpty_WhenSuitablePlantGeneraEmpty()
    {
        var viewModel = GardenStyleViewModel.Clone();
        viewModel.SuitablePlantGenera = Array.Empty<PlantGenus>();
        
        var gardenStyle = await GardenStyleMapper.ToModel(viewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Empty(gardenStyle.SuitablePlantGenera!);
    }
}