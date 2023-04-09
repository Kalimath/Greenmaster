using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.Placeables;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.PlaceableFactoryTests;

public class PlaceableFactoryTestBase
{
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

    public PlaceableFactoryTestBase()
    {
        Strelitzia = SpecieExamples.Strelitzia;
        ExamplesService = new ExamplesService();
        SomeCreationTime = PlaceableExamples.MatureStrelitziaPlant.Created;
        StrelitziaId = PlaceableExamples.MatureStrelitziaPlant.Id;
        StrelitziaMatureName = PlaceableExamples.MatureStrelitziaPlant.Name;
        StrelitziaMatureDimensions = ExamplesService.GetAllDimensions().First(d => d.Id == PlaceableExamples.MatureStrelitziaPlant.DimensionsId);
        StrelitziaLocation = ExamplesService.GetAllPoints().First(d => d.Id == PlaceableExamples.MatureStrelitziaPlant.LocationId);
        var strelitziaPlantTypeId = SpecieExamples.Strelitzia.PlantTypeId;
        StrelitziaPlantType = ExamplesService.GetPlantType(strelitziaPlantTypeId);
        StrelitziaViewModel = new PlaceableViewModel
        {
            Id = PlaceableExamples.MatureStrelitziaPlant.Id,
            Created = PlaceableExamples.MatureStrelitziaPlant.Created,
            Modified = PlaceableExamples.MatureStrelitziaPlant.Modified,
            Name = PlaceableExamples.MatureStrelitziaPlant.Name,
            Location = ExamplesService.GetAllPoints().First(point => point.Id == PlaceableExamples.MatureStrelitziaPlant.LocationId),
            DimensionsId = StrelitziaMatureDimensions.Id,
            Dimensions = StrelitziaMatureDimensions,
            TypeId = strelitziaPlantTypeId,
            Type = null,
            Specie = SpecieExamples.Strelitzia
        };
        StrelitziaPlaceable = PlaceableExamples.MatureStrelitziaPlant;
        StrelitziaPlaceable.DimensionsId = StrelitziaMatureDimensions.Id;
    }

    protected PlaceableViewModel CloneStrelitziaViewModel()
    {
        var clonedStrelitziaViewModel = StrelitziaViewModel.Clone();
        clonedStrelitziaViewModel.Type = StrelitziaPlantType;
        return clonedStrelitziaViewModel;
    }
    
    protected Placeable CloneStrelitziaPlaceable()
    {
        var clonedStrelitziaPlaceable = PlaceableExamples.MatureStrelitziaPlant;
        clonedStrelitziaPlaceable.DimensionsId = StrelitziaMatureDimensions.Id;
        clonedStrelitziaPlaceable.Dimensions = StrelitziaMatureDimensions;
        clonedStrelitziaPlaceable.Type = StrelitziaPlantType;
        clonedStrelitziaPlaceable.Specie = Strelitzia;
        clonedStrelitziaPlaceable.Location = StrelitziaLocation;
        
        return clonedStrelitziaPlaceable;
    }
    
    protected Placeable CloneStructurePlaceable()
    {
        var structure = PlaceableExamples.SwimmingPoolStructure;
        structure.DimensionsId = StrelitziaMatureDimensions.Id;
        structure.Dimensions = StrelitziaMatureDimensions;
        structure.Type = ObjectTypeExamples.SwimmingPool;
        structure.Location = PointExamples.GetAll().Find(p => p.Id == PlaceableExamples.SwimmingPoolStructure.LocationId);
        
        return structure;
    }
}