using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Factories;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.GardenStyleFactoryTests;

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

    [Fact]
    public void SetRequiresLargeGarden()
    {
        var viewModel = GardenStyleFactory.ToViewModel(GardenStyle);

        Assert.NotNull(viewModel);
        Assert.Equal(GardenStyle.RequiresLargeGarden, viewModel.RequiresLargeGarden);
    }
}