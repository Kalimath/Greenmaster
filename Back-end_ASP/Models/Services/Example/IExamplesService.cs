using Greenmaster_ASP.Models.Design;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.Placeables;

namespace Greenmaster_ASP.Models.Services.Example;

public interface IExamplesService
{
    List<Models.Specie> GetAllSpecies();
    List<Models.Rendering> GetAllRenderings();
    List<PlantType> GetAllPlantTypes();
    List<StructureType> GetAllStructureTypes();
    List<ObjectType> GetAllObjectTypes();
    PlantType GetPlantType(int plantTypeId);
    List<Point> GetAllPoints();
    List<Dimensions> GetAllDimensions();
    List<Placeable> GetAllPlaceables();
    List<Plant> GetAllPlants();
    List<Structure> GetAllStructures();
    List<GardenStyle> GetAllGardenStyles();
}