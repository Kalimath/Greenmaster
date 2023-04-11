using Greenmaster_ASP.Models.Placeables;

namespace Greenmaster_ASP.Models.Examples;

public static class PlaceableExamples 
{
    private static DateTime SomeDateTime = new (2020,12,27);
    private static DateTime SomeOtherDateTime = new (2023,8,27);
    
    public static readonly Plant MatureStrelitziaPlant = new ()
    { 
        Id = new Guid("BE6FD31E-38A6-400F-98C7-3C56C3207273"), 
        Created = SomeDateTime, 
        Modified = SomeOtherDateTime, 
        Name = SpecieExamples.Strelitzia.ScientificName+" (mature)",
        LocationId = PointExamples.PointOne.Id,
        DimensionsId = DimensionsExamples.DimensionsUp.Id,
        TypeId = SpecieExamples.Strelitzia.PlantTypeId,
        RenderingId = RenderingExamples.SummerTree.Id,
        SpecieId = SpecieExamples.Strelitzia.Id,
    };
    
    public static readonly Plant MaturePapaverPlant = new ()
    {
        Id = new Guid("6F8FB151-FD51-45EB-8D98-764EFFC7107E"), 
        Created = SomeOtherDateTime,
        Name = SpecieExamples.Papaver.ScientificName+" (mature)",
        LocationId = PointExamples.PointTwo.Id,
        DimensionsId = DimensionsExamples.DimensionsUp.Id,
        TypeId = SpecieExamples.Papaver.PlantTypeId,
        RenderingId = RenderingExamples.FallTree.Id,
        SpecieId = SpecieExamples.Papaver.Id,
    };

    public static readonly Structure SwimmingPoolStructure = new ()
    {
        Id = new Guid("C5DD401A-9898-48E2-AEF5-6FA102A79E29"), 
        Created = SomeDateTime,
        Name = "Large swimming pool",
        LocationId = PointExamples.PointTwo.Id,
        DimensionsId = DimensionsExamples.DimensionsFlat.Id,
        TypeId = ObjectTypeExamples.SwimmingPool.Id,
        RenderingId = RenderingExamples.SummerTree.Id
    };
    
    public static List<Placeable> GetAll()
    {
        return new List<Placeable>()
        {
            MatureStrelitziaPlant, MaturePapaverPlant, SwimmingPoolStructure
        };
    }
    
    public static List<Plant> GetAllPlants()
    {
        return new List<Plant>()
        {
            MatureStrelitziaPlant, MaturePapaverPlant
        };
    }
    
    public static List<Structure> GetAllStructures()
    {
        return new List<Structure>()
        {
            SwimmingPoolStructure
        };
    }
}