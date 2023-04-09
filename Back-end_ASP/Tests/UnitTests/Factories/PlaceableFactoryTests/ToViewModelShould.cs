using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Placeables;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.PlaceableFactoryTests;

public class ToViewModelShould : PlaceableFactoryTestBase
{

    [Fact]
    public void SetLocationNull_WhenLocationNullInPlaceable()
    {
        var placeableWithoutLocation = CloneStrelitziaPlaceable();
        placeableWithoutLocation.Location = null;
        
        var resultPlaceable = PlaceableFactory.ToViewModel(placeableWithoutLocation);
        
        Assert.NotNull(resultPlaceable);
        Assert.Null(resultPlaceable.Location);
    }
    
    [Fact]
    public void SetLocation_WhenLocationInPlaceableNotNull()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());

        Assert.NotNull(resultPlaceable);
        Assert.NotNull(resultPlaceable.Location);
        Assert.NotNull(StrelitziaLocation);
        Assert.Equal(StrelitziaLocation.Id, resultPlaceable.Location.Id);
        Assert.Equal(StrelitziaLocation.X, resultPlaceable.Location.X);
        Assert.Equal(StrelitziaLocation.Y, resultPlaceable.Location.Y);
        Assert.Equal(StrelitziaLocation.Z, resultPlaceable.Location.Z);
    }
    
    [Fact]
    public void SetDimensions_WhenDimensionsInPlaceableNotNull()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.NotNull(resultPlaceable.Dimensions);
    }
    
    [Fact]
    public void SetDimensionsId_WhenDimensionsIdInPlaceableValid()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaPlaceable.DimensionsId ,resultPlaceable.DimensionsId);
    }
    
    [Fact]
    public void SetId_WhenIdInPlaceableValid()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaId ,resultPlaceable.Id);
    }
    
    [Fact]
    public void SetCreated_WhenValidInPlaceable()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaPlaceable.Created ,resultPlaceable.Created);
    }
    
    [Fact]
    public void SetModifiedToCreated_WhenNullInPlaceable()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaPlaceable.Modified ,resultPlaceable.Modified);
    }
    
    [Fact]
    public void SetName_WhenValidInPlaceable()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(StrelitziaMatureName ,resultPlaceable.Name);
    }
    
    [Fact]
    public void SetSpecie_WhenPlaceableIsPlant()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.NotNull(resultPlaceable.Specie);
        Assert.Equal(Strelitzia.Id ,resultPlaceable.Specie.Id);
    }
    
    [Fact]
    public void SetSpecieNull_WhenPlaceableIsNotPlant()
    {
        var structurePlaceable = CloneStructurePlaceable();
        
        var resultPlaceable = PlaceableFactory.ToViewModel(structurePlaceable);
        
        Assert.NotNull(resultPlaceable);
        Assert.Null(resultPlaceable.Specie);
    }
    
    [Fact]
    public void SetType_WhenTypeOfPlaceableIsValid()
    {
        var resultPlaceable = PlaceableFactory.ToViewModel(CloneStrelitziaPlaceable());
        
        Assert.NotNull(resultPlaceable);
        Assert.NotNull(resultPlaceable.Type);
        Assert.Equal(StrelitziaPlantType ,resultPlaceable.Type);
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenPlaceableDimensionsNull()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Dimensions = null!;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenPlaceableTypeNull()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Type = null!;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenPlaceableTypeIsPlantTypeAndSpecieNull()
    {
        var placeable = (Plant)CloneStrelitziaPlaceable();
        placeable.Specie = null!;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableDimensionsAndDimensionsIdAreDefault()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.DimensionsId = 0;
        placeable.Dimensions = null!;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableNameNull()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Name = null!;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableNameEmpty()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Name = string.Empty;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableNameWhitespace()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Name = "   ";
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenPlaceableCreatedDefault()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Created = default!;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenPlaceableModifiedBeforeCreated()
    {
        var placeable = CloneStrelitziaPlaceable();
        placeable.Created = SomeCreationTime;
        placeable.Modified = SomeCreationTime.AddDays(-7);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = PlaceableFactory.ToViewModel(placeable));
    }
}