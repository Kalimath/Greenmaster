using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Placeables;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.PlaceableFactoryTests;

public class CreatePlaceableShould : PlaceableFactoryTestBase
{
    [Fact]
    public void SetLocationNull_WhenLocationNullInViewModel()
    {
        var viewModelWithoutLocation = CloneStrelitziaViewModel();
        viewModelWithoutLocation.Location = null!;
        
        var resultPlaceable = PlaceableFactory.Create(viewModelWithoutLocation);
        
        Assert.NotNull(resultPlaceable);
        Assert.Null(resultPlaceable.Location);
    }

    [Fact]
    public void SetLocation_WhenLocationInViewModel()
    {
        var resultPlaceable = PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.NotNull(resultPlaceable.Location);
        Assert.Equal(StrelitziaViewModel.Location!.Id, resultPlaceable.Location.Id);
        Assert.Equal(StrelitziaViewModel.Location!.X, resultPlaceable.Location.X);
        Assert.Equal(StrelitziaViewModel.Location!.Y, resultPlaceable.Location.Y);
        Assert.Equal(StrelitziaViewModel.Location!.Z, resultPlaceable.Location.Z);
    }
    
    [Fact]
    public void ReturnPlant_WhenSpecieNotNull()
    {
        var resultPlaceable = PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Plant>(resultPlaceable);
    }
    
    [Fact]
    public void ReturnStructure_WhenSpecieNull()
    {
        var structureViewModel = CloneStrelitziaViewModel();
        structureViewModel.Specie = null;
        
        var resultPlaceable = PlaceableFactory.Create(structureViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Structure>(resultPlaceable);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenSpecieNotNullAndTypeNotPlantType()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Type = ObjectTypeExamples.Garage;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenViewModelDimensionsNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Dimensions = null;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));

        invalidViewModel.Specie = null;
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenViewModelTypeNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Type = null;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));

        invalidViewModel.Specie = null;
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));
        
    }
    
    [Fact]
    public void SetDimensionsAndItsId()
    {
        var resultPlaceable = PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaViewModel.DimensionsId ,resultPlaceable.DimensionsId);
        Assert.NotNull(resultPlaceable.Dimensions);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenCreatedIsDefault()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Created = default!;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void SetModifiedToCreationDateWhenDefaultOrNull()
    {
        var validViewModel = CloneStrelitziaViewModel();
        validViewModel.Modified = default!;
        
        var resultPlaceable = PlaceableFactory.Create(validViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaViewModel.Created ,resultPlaceable.Modified);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableModifiedBeforeCreated()
    {
        var viewModel = CloneStrelitziaViewModel();
        viewModel.Created = SomeCreationTime;
        viewModel.Modified = SomeCreationTime.AddDays(-7);
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(viewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Specie = null!;
        
        var resultPlaceable = PlaceableFactory.Create(invalidViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Structure>(resultPlaceable);
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenDimensionsIdNotMatchingIdFromDimensions()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Dimensions = StrelitziaMatureDimensions;
        invalidViewModel.DimensionsId = StrelitziaMatureDimensions.Id + 5;
        
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Name = null!;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameEmpty()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Name = string.Empty;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameWhitespace()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Name = "   ";
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenDimensionsAndDimensionsIdNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.DimensionsId = default;
        invalidViewModel.Dimensions = null;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
}