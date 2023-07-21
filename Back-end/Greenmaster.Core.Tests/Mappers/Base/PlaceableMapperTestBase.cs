using Greenmaster.Core.Examples;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Models.Measurements;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Example;
using Point = Greenmaster.Core.Models.Point;

namespace Greenmaster.Core.Tests.Mappers.Base;

public class PlaceableMapperTestBase : RenderingMapperTestBase
{
    protected readonly IViewModelMapper<Placeable, PlaceableViewModel> Mapper;
    
    protected Guid StrelitziaId;
    protected readonly string StrelitziaMatureName;
    protected readonly Dimensions StrelitziaMatureDimensions;
    protected readonly PlaceableViewModel StrelitziaViewModel;
    protected readonly Point StrelitziaLocation;
    protected readonly IExamplesService ExamplesService;
    protected readonly PlantType StrelitziaPlantType;
    protected readonly Plant StrelitziaPlaceable;
    protected readonly Specie Strelitzia;
    protected DateTime SomeCreationTime;
    protected readonly Rendering StrelitziaRendering;
    protected readonly RenderingViewModel StrelitziaRenderingViewModel;
    protected readonly int StrelitziaPlantTypeId;

    public PlaceableMapperTestBase()
    {
        Mapper = new PlaceableMapper(RenderingMapper);
        
        Strelitzia = SpecieExamples.Strelitzia;
        ExamplesService = new ExamplesService();
        SomeCreationTime = PlaceableExamples.MatureStrelitziaPlant.Created;
        StrelitziaId = PlaceableExamples.MatureStrelitziaPlant.Id;
        StrelitziaMatureName = PlaceableExamples.MatureStrelitziaPlant.Name;
        StrelitziaMatureDimensions = DimensionsExamples.DimensionsUp;
        StrelitziaLocation = PointExamples.PointOne;
        StrelitziaPlantTypeId = SpecieExamples.Strelitzia.PlantTypeId;
        StrelitziaPlantType = ExamplesService.GetPlantType(StrelitziaPlantTypeId);
        StrelitziaRendering = RenderingExamples.SummerTree;
        StrelitziaViewModel = new PlaceableViewModel
        {
            Id = PlaceableExamples.MatureStrelitziaPlant.Id,
            Created = PlaceableExamples.MatureStrelitziaPlant.Created,
            Modified = PlaceableExamples.MatureStrelitziaPlant.Modified,
            Name = PlaceableExamples.MatureStrelitziaPlant.Name,
            LocationId = StrelitziaLocation.Id,
            Location = StrelitziaLocation,
            DimensionsId = StrelitziaMatureDimensions.Id,
            Dimensions = StrelitziaMatureDimensions,
            TypeId = StrelitziaPlantTypeId,
            Type = null,
            RenderingId = StrelitziaRendering.Id,
            Rendering = null,
            Specie = SpecieExamples.Strelitzia
        };
        StrelitziaPlaceable = PlaceableExamples.MatureStrelitziaPlant;
        StrelitziaPlaceable.DimensionsId = StrelitziaMatureDimensions.Id;
        StrelitziaRenderingViewModel = RenderingMapper.ToViewModel(StrelitziaRendering);
    }

    protected PlaceableViewModel CloneStrelitziaViewModel()
    {
        var clonedStrelitziaViewModel = new PlaceableViewModel
        {
            Id = PlaceableExamples.MatureStrelitziaPlant.Id,
            Created = PlaceableExamples.MatureStrelitziaPlant.Created,
            Modified = PlaceableExamples.MatureStrelitziaPlant.Modified,
            Name = PlaceableExamples.MatureStrelitziaPlant.Name,
            LocationId = StrelitziaLocation.Id,
            Location = StrelitziaLocation,
            DimensionsId = StrelitziaMatureDimensions.Id,
            Dimensions = StrelitziaMatureDimensions,
            TypeId = StrelitziaPlantTypeId,
            Type = null,
            RenderingId = StrelitziaRendering.Id,
            Rendering = null,
            Specie = SpecieExamples.Strelitzia
        };
        clonedStrelitziaViewModel.Type = StrelitziaPlantType;
        clonedStrelitziaViewModel.Rendering = StrelitziaRenderingViewModel;
        return clonedStrelitziaViewModel;
    }
    
    protected Placeable CloneStrelitziaPlaceable()
    {
        var clonedStrelitziaPlaceable = PlaceableExamples.MatureStrelitziaPlant.Clone();
        clonedStrelitziaPlaceable.DimensionsId = StrelitziaMatureDimensions.Id;
        clonedStrelitziaPlaceable.Dimensions = StrelitziaMatureDimensions;
        clonedStrelitziaPlaceable.Type = StrelitziaPlantType;
        clonedStrelitziaPlaceable.Specie = Strelitzia;
        clonedStrelitziaPlaceable.LocationId = StrelitziaLocation.Id;
        clonedStrelitziaPlaceable.Location = StrelitziaLocation;
        clonedStrelitziaPlaceable.RenderingId = StrelitziaRendering.Id;
        clonedStrelitziaPlaceable.Rendering = StrelitziaRendering;
        
        return clonedStrelitziaPlaceable;
    }
    
    protected Placeable CloneStructurePlaceable()
    {
        var structure = PlaceableExamples.SwimmingPoolStructure.Clone();
        structure.DimensionsId = StrelitziaMatureDimensions.Id;
        structure.Dimensions = StrelitziaMatureDimensions;
        structure.Type = ObjectTypeExamples.SwimmingPool;
        structure.LocationId = StrelitziaLocation.Id;
        structure.Location = StrelitziaLocation;
        structure.Rendering = StrelitziaRendering;
        structure.RenderingId = StrelitziaRendering.Id;
        
        return structure;
    }
}