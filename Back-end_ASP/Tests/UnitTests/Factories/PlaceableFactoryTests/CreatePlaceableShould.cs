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
    private readonly PlantType _strelitziaPlantType;

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
        var strelitziaPlantTypeId = SpecieExamples.Strelitzia.PlantTypeId;
        _strelitziaPlantType = _examplesService.GetPlantType(strelitziaPlantTypeId);
        _strelitziaViewModel = new PlaceableViewModel
        {
            Id = _strelitziaId,
            Created = _strelitziaCreationTime,
            Modified = _strelitziaCreationTime,
            Name = _strelitziaMatureName,
            Location = _somelocation,
            DimensionsId = _strelitziaMatureDimensions.Id,
            Dimensions = _strelitziaMatureDimensions,
            TypeId = strelitziaPlantTypeId,
            Type = null,
            Specie = SpecieExamples.Strelitzia
        };
    }
    
    private PlaceableViewModel CloneStrelitziaViewModel()
    {
        var clonedStrelitziaViewModel = _strelitziaViewModel.Clone();
        clonedStrelitziaViewModel.Type = _strelitziaPlantType;
        return clonedStrelitziaViewModel;
    }

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
        Assert.Equal(_strelitziaViewModel.Location!.Id, resultPlaceable.Location.Id);
        Assert.Equal(_strelitziaViewModel.Location!.X, resultPlaceable.Location.X);
        Assert.Equal(_strelitziaViewModel.Location!.Y, resultPlaceable.Location.Y);
        Assert.Equal(_strelitziaViewModel.Location!.Z, resultPlaceable.Location.Z);
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
        Assert.Equal(_strelitziaViewModel.DimensionsId ,resultPlaceable.DimensionsId);
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
        Assert.Equal(_strelitziaViewModel.Created ,resultPlaceable.Modified);
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