using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Measurements;
using Greenmaster.Core.Models.Placeables;

namespace Greenmaster.Core.Services.Example;

public interface IExamplesService
{
    List<Models.Specie> GetAllSpecies();
    List<Models.Rendering> GetAllRenderings();
    List<PlantType> GetAllPlantTypes();
    List<StructureType> GetAllStructureTypes();
    List<ObjectType> GetAllObjectTypes();
    PlantType GetPlantType(Guid plantTypeId);
    List<Point> GetAllPoints();
    List<Dimensions> GetAllDimensions();
    List<Placeable> GetAllPlaceables();
    List<Plant> GetAllPlants();
    List<Structure> GetAllStructures();
    List<Models.Design.GardenStyle> GetAllGardenStyles();
    List<Models.Design.MaterialType> GetAllMaterialTypes();
}