using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.Placeables;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.ViewModels;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.PlaceableFactoryTests;

public class CreatePlaceableShould
{
    private readonly DateTime _strelitziaCreationTime;
    private readonly Guid _strelitziaId;
    private readonly string _strelitziaMatureName;
    private readonly Dimensions _strelitziaMatureDimensions;
    private readonly PlaceableViewModel _strelitziaViewModel;
    private readonly Point _somelocation;
    private readonly IExamplesService _examplesService;

    public CreatePlaceableShould()
    {
        _examplesService = new ExamplesService();
        _strelitziaCreationTime = DateTime.Now;
        _strelitziaId = Guid.NewGuid();
        _strelitziaMatureName = SpecieExamples.Strelitzia.ScientificName+" (mature)";
        _strelitziaMatureDimensions = new Dimensions
        {
            Id = 1,
            Height = SpecieExamples.Strelitzia.MaxHeight,
            Width = SpecieExamples.Strelitzia.MaxWidth
        };
        _somelocation = new Point
        {
            Id = 24,
            X = 122,
            Y = 687,
            Z = 3
        };
        _strelitziaViewModel = new PlaceableViewModel
        {
            Id = _strelitziaId,
            Created = _strelitziaCreationTime,
            Modified = _strelitziaCreationTime,
            Name = _strelitziaMatureName,
            Location = _somelocation,
            DimensionsId = _strelitziaMatureDimensions.Id,
            Dimensions = _strelitziaMatureDimensions,
            TypeId = SpecieExamples.Strelitzia.PlantTypeId,
            Type = null,
            Specie = SpecieExamples.Strelitzia
        };
    }

    [Fact]
    public void SetLocationNull_WhenLocationNullInViewModel()
    {
        var viewModelWithoutLocation = _strelitziaViewModel.Clone();
        viewModelWithoutLocation.Location = null!;
        
        var resultPlaceable = PlaceableFactory.Create(viewModelWithoutLocation);
        
        Assert.NotNull(resultPlaceable);
        Assert.Null(resultPlaceable.Location);
    }
    
    [Fact]
    public void SetLocation_WhenLocationInViewModel()
    {
        var resultPlaceable = PlaceableFactory.Create(_strelitziaViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(_strelitziaViewModel.Location, resultPlaceable.Location);
    }
    
    [Fact]
    public void ReturnPlant_WhenSpecieNotNull()
    {
        var resultPlaceable = PlaceableFactory.Create(_strelitziaViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Plant>(resultPlaceable);
    }
    
    [Fact]
    public void ReturnStructure_WhenSpecieNull()
    {
        var structureViewModel = _strelitziaViewModel.Clone();
        structureViewModel.Specie = null;
        
        var resultPlaceable = PlaceableFactory.Create(structureViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Structure>(resultPlaceable);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenSpecieNotNullAndTypeNotPlantType()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Type = ObjectTypeExamples.Garage;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void SetDimensionsAndItsId()
    {
        var resultPlaceable = PlaceableFactory.Create(_strelitziaViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(_strelitziaViewModel.DimensionsId ,resultPlaceable.DimensionsId);
        Assert.NotNull(resultPlaceable.Dimensions);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenCreatedIsDefault()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Created = default!;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void SetModifiedToCreationDateWhenDefaultOrNull()
    {
        var validViewModel = _strelitziaViewModel.Clone();
        validViewModel.Modified = default!;
        
        var resultPlaceable = PlaceableFactory.Create(validViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.Equal(_strelitziaViewModel.Created ,resultPlaceable.Modified);
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieNull()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Specie = null!;
        
        var resultPlaceable = PlaceableFactory.Create(invalidViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.IsType<Structure>(resultPlaceable);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameNull()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Name = null!;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameEmpty()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Name = string.Empty;
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenNameWhitespace()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Name = "   ";
        
        Assert.Throws<ArgumentException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenDimensionsAndDimensionsIdNull()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.DimensionsId = default;
        invalidViewModel.Dimensions = null;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));
    }
}