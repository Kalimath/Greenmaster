namespace Greenmaster_ASP.Models.Examples;

public interface IExamplesService
{
    List<Specie> GetAllSpecies();
    List<Rendering> GetAllRenderings();
    List<PlantType> GetAllPlantTypes();
    List<StructureType> GetAllStructureTypes();
    List<ObjectType> GetAllObjectTypes();
}

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

    public List<StructureType> GetAllStructureTypes()
    {
        throw new NotImplementedException();
    }

    public List<ObjectType> GetAllObjectTypes()
    {
        throw new NotImplementedException();
    }
}