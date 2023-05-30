namespace Greenmaster.Core.Examples;

public static class MaterialTypeExamples
{
    public static MaterialType Wood => new()
    {
        Id = 1,
        Name = "Wood",
        Description = "Wood"
    };

    public static MaterialType Stone => new()
    {
        Id = 2,
        Name = "Stone",
        Description = "Stone"
    };

    public static MaterialType Brick => new()
    {
        Id = 3,
        Name = "Brick",
        Description = "Brick"
    };

    public static MaterialType CortenSteel => new()
    {
        Id = 4,
        Name = "Corten steel",
        Description = "Corten steel, is a group of steel alloys which were developed to eliminate the need for painting, and form a stable rust-like appearance."
    };

    public static MaterialType Gabion => new()
    {
        Id = 5,
        Name = "Gabion",
        Description = "A gabion is a cage, cylinder or box filled with rocks, concrete, or sometimes sand and soil."
    };
    
    
    public static List<MaterialType> GetAll() => new()
    {
        Wood,
        Stone,
        Brick,
        CortenSteel,
        Gabion
    };
}