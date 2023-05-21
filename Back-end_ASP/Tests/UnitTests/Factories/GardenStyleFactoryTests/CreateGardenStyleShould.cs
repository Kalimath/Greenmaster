using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Factories;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.GardenStyleFactoryTests;

public class CreateGardenStyleShould : GardenStyleFactoryTestBase
{

    [Fact]
    public void ThrowArgumentNullException_WhenGardenStyleIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => GardenStyleFactory.Create(null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void ThrowArgumentException_WhenNameInvalid(string name)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Name = name;

        Assert.Throws<ArgumentException>(() => GardenStyleFactory.Create(gardenStyleViewModel));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void ThrowArgumentException_WhenDescriptionInvalid(string description)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Description = description;

        Assert.Throws<ArgumentException>(() => GardenStyleFactory.Create(gardenStyleViewModel));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void ThrowArgumentOutOfRangeException_WhenIdInvalid(int id)
    {
        var gardenStyleViewModel = GardenStyleViewModel.Clone();
        gardenStyleViewModel.Id = id;
        
        Assert.Throws<ArgumentOutOfRangeException>(() => GardenStyleFactory.Create(gardenStyleViewModel));
    }

    [Fact]
    public void SetId_WhenValid()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Id, gardenStyle.Id);
    }

    [Fact]
    public void SetName_WhenValid()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Name, gardenStyle.Name);
    }

    [Fact]
    public void SetDescription_WhenValid()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Description, gardenStyle.Description);
    }

    [Fact]
    public void SetColors_WhenPresent()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Colors, gardenStyle.Colors);
    }

    [Fact]
    public void SetConcepts_WhenPresent()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);
        
        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Concepts, gardenStyle.Concepts);
    }

    [Fact]
    public void SetShapes_WhenPresent()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.Shapes, gardenStyle.Shapes);
    }

    [Fact]
    public void SetRequiresLargeGarden()
    {
        var gardenStyle = GardenStyleFactory.Create(GardenStyleViewModel);

        Assert.NotNull(gardenStyle);
        Assert.Equal(GardenStyleViewModel.RequiresLargeGarden, gardenStyle.RequiresLargeGarden);
    }
}