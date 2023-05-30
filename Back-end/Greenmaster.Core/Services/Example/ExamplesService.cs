using Greenmaster.Core.Examples;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Measurements;
using Greenmaster.Core.Models.Placeables;

namespace Greenmaster.Core.Services.Example;

public class ExamplesService : IExamplesService
{
    public List<Models.Specie> GetAllSpecies()
    {
        return SpecieExamples.GetAll();
    }

    public List<Models.Rendering> GetAllRenderings()
    {
        return RenderingExamples.GetAll();
    }
    
    public List<PlantType> GetAllPlantTypes()
    {
        return ObjectTypeExamples.GetAllPlantTypes();
    }
    
    public PlantType GetPlantType(int plantTypeId)
    {
        return ObjectTypeExamples.GetAllPlantTypes().First(type => type.Id == plantTypeId);
    }

    public List<Point> GetAllPoints()
    {
        return PointExamples.GetAll();
    }
    
    public List<Dimensions> GetAllDimensions()
    {
        return DimensionsExamples.GetAll();
    }

    public List<Placeable> GetAllPlaceables()
    {
        return PlaceableExamples.GetAll();
    }

    public List<Plant> GetAllPlants()
    {
        return PlaceableExamples.GetAllPlants();
    }

    public List<Structure> GetAllStructures()
    {
        return PlaceableExamples.GetAllStructures();
    }

    public List<Models.Design.GardenStyle> GetAllGardenStyles()
    {
        return GardenStyleExamples.GetAll();
    }

    public List<Models.Design.MaterialType> GetAllMaterialTypes()
    {
        return MaterialTypeExamples.GetAll();
    }

    public List<StructureType> GetAllStructureTypes()
    {
        return ObjectTypeExamples.GetAllStructureTypes();
    }

    public List<ObjectType> GetAllObjectTypes()
    {
        var allObjectTypes = new List<ObjectType>();
        allObjectTypes.AddRange(GetAllStructureTypes());
        allObjectTypes.AddRange(GetAllPlantTypes());
        return allObjectTypes;
    }
}