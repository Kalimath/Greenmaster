using System.Drawing;
using Greenmaster_ASP.Models.Design;
using Greenmaster_ASP.Models.Static.Design;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Size = Greenmaster_ASP.Models.Static.Measuring.Size;

namespace Greenmaster_ASP.Models.Examples;

public static class GardenStyleExamples
{
    public static readonly GardenStyle ModernAndMinimal = new()
    {
        Id = 1,
        Name = "Modern and minimal",
        Description =
            "If you love sharp, clean lines, clutter-free spaces and a contemporary feel, then modern and minimal garden design is perfect for you.",
        Concepts = new[]
        {
            GardenStyleConcept.StraightLines.ToString(),
            GardenStyleConcept.CurvedLines.ToString()
        },
        Shapes = new[]
        {
            Shape.Round.ToString(),
            Shape.Cubic.ToString()
        },
        Colors = new[]
        {
            Color.White.ToString(),
            Color.Green.ToString(),
            Color.Blue.ToString()
        },
        RequiresLargeGarden = false,
        PathSize = Size.Small,
        Materials = Array.Empty<MaterialType>(),

    };
    
    public static List<GardenStyle> GetAll()
    {
        return new List<GardenStyle>()
        {
            ModernAndMinimal
        };
    }
}