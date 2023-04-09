using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.Placeables;

namespace Greenmaster_ASP.Models.Services;

public interface IExamplesService
{
    List<Specie> GetAllSpecies();
    List<Rendering> GetAllRenderings();
    List<PlantType> GetAllPlantTypes();
    List<StructureType> GetAllStructureTypes();
    List<ObjectType> GetAllObjectTypes();
    PlantType GetPlantType(int plantTypeId);
    List<Point> GetAllPoints();
    List<Dimensions> GetAllDimensions();
    List<Placeable> GetAllPlaceables();
    List<Plant> GetAllPlants();
    List<Structure> GetAllStructures();
}