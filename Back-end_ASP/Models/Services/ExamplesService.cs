using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Services;

public class ExamplesService : IExamplesService
{
    public List<Specie> GetAllSpecies()
    {
        return SpecieExamples.GetAll();
    }

    public List<Rendering> GetAllRenderings()
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