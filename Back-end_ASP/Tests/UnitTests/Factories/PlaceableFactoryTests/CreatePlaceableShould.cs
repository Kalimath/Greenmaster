using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.Placeables;
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

    public CreatePlaceableShould()
    {
        _strelitziaCreationTime = DateTime.Now;
        _strelitziaId = Guid.NewGuid();
        _strelitziaMatureName = SpecieExamples.Strelitzia.ScientificName+" (mature)";
        _strelitziaMatureDimensions = new Dimensions
        {
            Id = 1,
            Height = SpecieExamples.Strelitzia.MaxHeight,
            Width = SpecieExamples.Strelitzia.MaxWidth
        };
        _strelitziaViewModel = new PlaceableViewModel
        {
            Id = _strelitziaId,
            Created = _strelitziaCreationTime,
            Modified = _strelitziaCreationTime,
            Name = _strelitziaMatureName,
            Location = null,
            DimensionsId = _strelitziaMatureDimensions.Id,
            Dimensions = _strelitziaMatureDimensions,
            Type = SpecieExamples.Strelitzia.PlantType,
            Specie = SpecieExamples.Strelitzia
        };
    }

    [Fact]
    public void SetLocationNull_WhenLocationInViwModel()
    {
        var resultPlaceable = PlaceableFactory.Create(_strelitziaViewModel);
        
        Assert.NotNull(resultPlaceable);
        Assert.Null(resultPlaceable.Location);
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
    public void ThrowArgumentNullException_WhenDimensionsNull()
    {
        var invalidViewModel = _strelitziaViewModel.Clone();
        invalidViewModel.Dimensions = null!;
        
        Assert.Throws<ArgumentNullException>(() => _ = PlaceableFactory.Create(invalidViewModel));
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
}

public static class PlaceableFactory
{
    public static Placeable Create(PlaceableViewModel viewModel)
    {
        return new Plant
        {
            Id = viewModel.Id,
            Created = viewModel.Created ?? throw new ArgumentException(nameof(viewModel.Created)),
            Modified = (DateTime)(viewModel.Modified ?? viewModel.Created!),
            Name = viewModel.Name,
            Location = viewModel.Location,
            DimensionsId = viewModel.DimensionsId,
            Dimensions = viewModel.Dimensions ?? throw new ArgumentNullException(nameof(viewModel.Dimensions)),
            Type = viewModel.Type,
            Specie = viewModel.Specie
        };
    }
}