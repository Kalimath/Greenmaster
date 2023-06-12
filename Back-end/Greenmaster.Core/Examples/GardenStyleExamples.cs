using System.Drawing;
using Greenmaster.Core.Models.Extensions;
using StaticData.Coloring;
using StaticData.Design;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using Size = StaticData.Measuring.Size;

namespace Greenmaster.Core.Examples;

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
            GardenStyleConcept.Geometric.ToString()
        },
        Shapes = new[]
        {
            Shape.Round.ToString(),
            Shape.Cubic.ToString()
        },
        Colors = new[]
        {
            Color.White,
            Color.Green,
            Color.Blue
        }.GetNames().ToArray(),
        RequiresLargeGarden = false,
        AllSeasonInterest = false,
        DivideIntoRooms = false,
        PathSize = Size.Small,
        Materials = Array.Empty<MaterialType>(),
        SuitablePlantGenera = new []
        {
            PlantGenus.Ginkgo
        },

    };
    
    public static readonly GardenStyle EnglishCountry = new()
    {
        Id = 2,
        Name = "English country",
        Description =
            "Wide paths, deep herbaceous borders, structures, pools, rills, structures, terraces and lavishly planted pots.",
        Concepts = new[]
        {
            GardenStyleConcept.Herbaceous.ToString(),
            GardenStyleConcept.Topiary.ToString(),
            GardenStyleConcept.Sculptured.ToString(),
            GardenStyleConcept.Colorful.ToString()
        },
        Shapes = new[]
        {
            Shape.NotSet.ToString()
        },
        Colors = ColorPallet.BaseColors().GetNames().ToArray(),
        RequiresLargeGarden = true,
        AllSeasonInterest = true,
        DivideIntoRooms = true,
        PathSize = Size.Large,
        Materials = Array.Empty<MaterialType>(),
        SuitablePlantGenera = new []
        {
            PlantGenus.Iris, PlantGenus.Delphinium, PlantGenus.Rosa
        }

    };
    //TODO: add plantTypes & structureTypes
    //TODO: add species matching style
    
    public static List<GardenStyle> GetAll()
    {
        return new List<GardenStyle>()
        {
            ModernAndMinimal, EnglishCountry
        };
    }
}