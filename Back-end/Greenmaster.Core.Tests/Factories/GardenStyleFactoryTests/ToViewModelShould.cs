using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Tests.Factories.Base;

namespace Greenmaster.Core.Tests.Factories.GardenStyleFactoryTests;

public class ToViewModelShould : GardenStyleFactoryTestBase
{
    [Fact]
    public void ThrowArgumentNullException_WhenGardenStyleIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => GardenStyleFactory.ToViewModel(null!));
    }
    
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void ThrowArgumentException_WhenNameInvalid(string name)
    {
        var gardenStyle = GardenStyle.Clone();
        gardenStyle.Name = name;

        Assert.Throws<ArgumentException>(() => GardenStyleFactory.ToViewModel(gardenStyle));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void ThrowArgumentException_WhenDescriptionInvalid(string description)
    {
        var gardenStyle = GardenStyle.Clone();
        gardenStyle.Description = description;

        Assert.Throws<ArgumentException>(() => GardenStyleFactory.ToViewModel(gardenStyle));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void ThrowArgumentOutOfRangeException_WhenIdInvalid(int id)
    {
        var gardenStyle = GardenStyle.Clone();
        gardenStyle.Id = id;
        
        Assert.Throws<ArgumentOutOfRangeException>(() => GardenStyleFactory.ToViewModel(gardenStyle));
    }

    [Fact]
    public void SetId_WhenValid()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);

        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Id, viewModel.Id);
    }

    [Fact]
    public void SetPathSize_WhenValid()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);

        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.PathSize, viewModel.PathSize);
    }

    [Fact]
    public void SetMaterials_WhenValid()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);

        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Materials, viewModel.Materials);
    }

    [Fact]
    public void SetName_WhenValid()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);
        
        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Name, viewModel.Name);
    }

    [Fact]
    public void SetDescription_WhenValid()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);

        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Description, viewModel.Description);
    }

    [Fact]
    public void SetColors_WhenPresent()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);
        
        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Colors, viewModel.Colors);
    }

    [Fact]
    public void SetConcepts_WhenPresent()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);
        
        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Concepts, viewModel.Concepts);
    }

    [Fact]
    public void SetShapes_WhenPresent()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);

        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.Shapes, viewModel.Shapes);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SetAllSeasonInterest_WhenPresent( bool allSeasonInterest)
    {
        var gardenStyleWithAllSeasonInterest = GardenStyle.Clone(); 
        gardenStyleWithAllSeasonInterest.AllSeasonInterest = allSeasonInterest;
        
        var viewModel = GardenStyleFactory.ToViewModel(gardenStyleWithAllSeasonInterest);
        
        Assert.NotNull(viewModel);
        Assert.Equal(allSeasonInterest, viewModel.AllSeasonInterest);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SetRequiresLargeGarden(bool requiresLargeGarden)
    {
        var gardenStyleForLargeGardens = GardenStyle.Clone();
        gardenStyleForLargeGardens.RequiresLargeGarden = requiresLargeGarden;
        
        var viewModel = GardenStyleFactory.ToViewModel(gardenStyleForLargeGardens);

        Assert.NotNull(viewModel);
        Assert.Equal(requiresLargeGarden, viewModel.RequiresLargeGarden);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SetDivideIntoRooms(bool divideIntoRooms)
    {
        var gardenStyleDividedIntoRooms = GardenStyle.Clone();
        gardenStyleDividedIntoRooms.DivideIntoRooms = divideIntoRooms;
        
        var viewModel = GardenStyleFactory.ToViewModel(gardenStyleDividedIntoRooms);

        Assert.NotNull(viewModel);
        Assert.Equal(divideIntoRooms, viewModel.DivideIntoRooms);
    }
}