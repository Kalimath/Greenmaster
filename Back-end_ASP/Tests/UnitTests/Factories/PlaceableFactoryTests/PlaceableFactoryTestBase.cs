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
    protected readonly Point SomeLocation;
    protected readonly IExamplesService ExamplesService;
    protected readonly PlantType StrelitziaPlantType;
    protected readonly Plant StrelitziaPlaceable;
    protected readonly Specie Strelitzia;
    protected DateTime SomeCreationTime;

    public PlaceableFactoryTestBase()
    {
        Strelitzia = SpecieExamples.Strelitzia;
        ExamplesService = new ExamplesService();
        SomeCreationTime = DateTime.Now;
        StrelitziaId = Guid.NewGuid();
        StrelitziaMatureName = SpecieExamples.Strelitzia.ScientificName+" (mature)";
        StrelitziaMatureDimensions = new Dimensions
        {
            Id = 1,
            Height = SpecieExamples.Strelitzia.MaxHeight,
            Width = SpecieExamples.Strelitzia.MaxWidth
        };
        SomeLocation = new Point
        {
            Id = 24,
            X = 122,
            Y = 687,
            Z = 3
        };
        var strelitziaPlantTypeId = SpecieExamples.Strelitzia.PlantTypeId;
        StrelitziaPlantType = ExamplesService.GetPlantType(strelitziaPlantTypeId);
        StrelitziaViewModel = new PlaceableViewModel
        {
            Id = StrelitziaId,
            Created = SomeCreationTime,
            Modified = SomeCreationTime,
            Name = StrelitziaMatureName,
            Location = SomeLocation,
            DimensionsId = StrelitziaMatureDimensions.Id,
            Dimensions = StrelitziaMatureDimensions,
            TypeId = strelitziaPlantTypeId,
            Type = null,
            Specie = SpecieExamples.Strelitzia
        };
        StrelitziaPlaceable = new Plant(StrelitziaId, StrelitziaMatureName, SpecieExamples.Strelitzia,
            Strelitzia.PlantTypeId, DimensionsExamples.DimensionsUp, SomeCreationTime, null, PointExamples.PointOne);
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
        var clonedStrelitziaPlaceable = new Plant(StrelitziaId, StrelitziaMatureName, SpecieExamples.Strelitzia, Strelitzia.PlantTypeId,  DimensionsExamples.DimensionsUp, SomeCreationTime, null, PointExamples.PointOne);
        clonedStrelitziaPlaceable.DimensionsId = StrelitziaMatureDimensions.Id;
        clonedStrelitziaPlaceable.Type = StrelitziaPlantType;
        
        return clonedStrelitziaPlaceable;
    }
    
    protected Placeable CloneStructurePlaceable()
    {
        var structure = new Structure(Guid.NewGuid(), "Large swimming pool", ObjectTypeExamples.SwimmingPool.Id,
            DimensionsExamples.DimensionsFlat, SomeCreationTime, null, PointExamples.PointTwo);
        structure.DimensionsId = StrelitziaMatureDimensions.Id;
        structure.Type = ObjectTypeExamples.SwimmingPool;
        
        return structure;
    }
}