using eu.greenmaster.Models;
using eu.greenmaster.Models.Measurements;
using eu.greenmaster.Models.Placeables;
using ObjectType = eu.greenmaster.Models.ObjectType;
using Point = eu.greenmaster.Models.Point;

namespace eu.greenmaster.Repository.Services.Example;

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
}