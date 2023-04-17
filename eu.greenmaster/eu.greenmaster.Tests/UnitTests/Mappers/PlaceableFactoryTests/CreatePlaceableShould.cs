using eu.greenmaster.Examples;
using eu.greenmaster.Models.Factories;
using eu.greenmaster.Models.Placeables;

namespace eu.greenmaster.Tests.UnitTests.Factories.PlaceableFactoryTests;

public class CreatePlaceableShould : PlaceableFactoryTestBase
{
    [Fact]
    public async Task SetLocationNull_WhenLocationNullInViewModel()
    {
        var viewModelWithoutLocation = CloneStrelitziaViewModel();
        viewModelWithoutLocation.Location = null!;
        
        var resultPlaceable = await PlaceableFactory.Create(viewModelWithoutLocation);
        
        Assert.NotNull(resultPlaceable);
        Assert.Null(resultPlaceable.Location);
    }

    [Fact]
    public async Task SetLocation_WhenLocationInViewModel()
    {
        var resultPlaceable = await PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.NotNull(resultPlaceable.Location);
        Assert.Equal(StrelitziaViewModel.Location!.Id, resultPlaceable.Location.Id);
        Assert.Equal(StrelitziaViewModel.Location!.X, resultPlaceable.Location.X);
        Assert.Equal(StrelitziaViewModel.Location!.Y, resultPlaceable.Location.Y);
        Assert.Equal(StrelitziaViewModel.Location!.Z, resultPlaceable.Location.Z);
    }
    
    [Fact]
    public async Task ReturnPlant_WhenSpecieNotNull()
    {
        var resultPlaceable = await PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Plant>(resultPlaceable);
    }
    
    [Fact]
    public async Task ReturnStructure_WhenSpecieNull()
    {
        var structureViewModel = CloneStrelitziaViewModel();
        structureViewModel.Specie = null;
        
        var resultPlaceable = await PlaceableFactory.Create(structureViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Structure>(resultPlaceable);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenSpecieNotNullAndTypeNotPlantType()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Type = ObjectTypeExamples.Garage;
        
        Assert.ThrowsAsync<ArgumentException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenViewModelDimensionsNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Dimensions = null;
        
        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));

        invalidViewModel.Specie = null;
        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenViewModelTypeNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Type = null;
        
        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));

        invalidViewModel.Specie = null;
        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
        
    }
    
    [Fact]
    public async Task SetDimensionsAndItsId()
    {
        var resultPlaceable = await PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaViewModel.DimensionsId ,resultPlaceable.DimensionsId);
        Assert.NotNull(resultPlaceable.Dimensions);
    }
    
    [Fact]
    public async Task SetRendering_whenNotNull()
    {
        //TODO
        var resultPlaceable = await PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaRendering!.Id ,resultPlaceable.Rendering.Id);
        Assert.NotNull(resultPlaceable.Rendering);
    }
    
    [Fact]
    public async Task SetRenderingId_whenNotZero()
    {
        var resultPlaceable = await PlaceableFactory.Create(CloneStrelitziaViewModel());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaRendering.Id ,resultPlaceable.RenderingId);
        Assert.NotNull(resultPlaceable.Rendering);
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenRenderingIdNotMatchingIdFromRendering()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Rendering = StrelitziaRenderingViewModel;
        invalidViewModel.DimensionsId = StrelitziaRenderingViewModel.Id + 5;
        
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenRenderingIsNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Rendering = null!;
        
        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenCreatedIsDefault()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Created = default!;
        
        Assert.ThrowsAsync<ArgumentException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public async Task SetModifiedToCreationDateWhenDefaultOrNull()
    {
        var validViewModel = CloneStrelitziaViewModel();
        validViewModel.Modified = default!;
        
        var resultPlaceable = await PlaceableFactory.Create(validViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaViewModel.Created ,resultPlaceable.Modified);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableModifiedBeforeCreated()
    {
        var viewModel = CloneStrelitziaViewModel();
        viewModel.Created = SomeCreationTime;
        viewModel.Modified = SomeCreationTime.AddDays(-7);
        
        Assert.ThrowsAsync<ArgumentException>(async () => _ = await PlaceableFactory.Create(viewModel));
    }
    
    [Fact]
    public async Task ThrowArgumentNullException_WhenSpecieNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Specie = null!;
        
        var resultPlaceable = await PlaceableFactory.Create(invalidViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Structure>(resultPlaceable);
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenDimensionsIdNotMatchingIdFromDimensions()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Dimensions = StrelitziaMatureDimensions;
        invalidViewModel.DimensionsId = StrelitziaMatureDimensions.Id + 5;
        
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Name = null!;
        
        Assert.ThrowsAsync<ArgumentException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameEmpty()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Name = string.Empty;
        
        Assert.ThrowsAsync<ArgumentException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameWhitespace()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.Name = "   ";
        
        Assert.ThrowsAsync<ArgumentException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenDimensionsAndDimensionsIdNull()
    {
        var invalidViewModel = CloneStrelitziaViewModel();
        invalidViewModel.DimensionsId = default;
        invalidViewModel.Dimensions = null;
        
        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PlaceableFactory.Create(invalidViewModel));
    }
}