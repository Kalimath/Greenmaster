namespace Greenmaster_ASP.Models.Services;

public interface IExamplesService
{
    List<Specie> GetAllSpecies();
    List<Rendering> GetAllRenderings();
    List<PlantType> GetAllPlantTypes();
    List<StructureType> GetAllStructureTypes();
    List<ObjectType> GetAllObjectTypes();
    PlantType GetPlantType(int plantTypeId);
}