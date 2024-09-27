using System.Drawing;
using Greenmaster.Core.Extensions;
using StaticData.Coloring;
using StaticData.Design;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using Color = StaticData.Coloring.Color;
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
            Shape.Round.ToString(), //TODO: check if it is better to just pass the enum value instead of string
            Shape.Cubic.ToString()
        },
        Colors = new[]
        {
            Color.White,
            Color.Green,
            Color.Blue
        },
        RequiresLargeGarden = false,
        AllSeasonInterest = false,
        DivideIntoRooms = false,
        PathSize = Size.Small,
        Materials = new List<MaterialType>(),
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
        Colors = ColorPallet.BaseColors(),
        RequiresLargeGarden = true,
        AllSeasonInterest = true,
        DivideIntoRooms = true,
        PathSize = Size.Large,
        Materials = new List<MaterialType>(),
        SuitablePlantGenera = new []
        {
            PlantGenus.Iris, PlantGenus.Delphinium, PlantGenus.Rosa
        }

    };
    
    public static readonly GardenStyle Cottage = new()
    {
        Id = 3,
        Name = "Cottage",
        Description =
            "Cottage gardens are made up of a mix of colours, as opposed to a strict colour scheme. " +
            "Cottage gardens are also likely to make use of self-seeding plants such as foxgloves and aquilegias, " +
            "which pop up spontaneously around the garden or in cracks in paving, adding to the informal look.",
        Concepts = new[]
        {
            GardenStyleConcept.Herbaceous.ToString(),
            GardenStyleConcept.Cramped.ToString(),
            GardenStyleConcept.Topiary.ToString(),
            GardenStyleConcept.Sculptured.ToString(),
            GardenStyleConcept.NoLawn.ToString(),
            GardenStyleConcept.Colorful.ToString(),
            GardenStyleConcept.SelfSeeding.ToString(),
            GardenStyleConcept.Geometric.ToString()
        },
        Shapes = new[]
        {
            Shape.NotSet.ToString()
        },
        Colors = ColorPallet.Colors(), //TODO: change this to a Color type and store in db as hex and write a converter function
        RequiresLargeGarden = false,
        AllSeasonInterest = true,
        DivideIntoRooms = true,
        PathSize = Size.Small,
        Materials = new List<MaterialType>(),
        SuitablePlantGenera = new []
        {
            PlantGenus.Aquilegia, 
            PlantGenus.Geranium, 
            PlantGenus.Phlox, 
            PlantGenus.Delphinium,
            PlantGenus.Lupinus,
            PlantGenus.Lonicera,
            PlantGenus.Campanula,
            PlantGenus.Lavandula,
            PlantGenus.Alcea,
            PlantGenus.Paeonia,
            PlantGenus.Rosa,
            PlantGenus.Allium,
            PlantGenus.Tulipa,
            PlantGenus.Narcissus,
            PlantGenus.Clematis,
            PlantGenus.Alchemilla,
            PlantGenus.Dianthus,
            PlantGenus.Digitalis,
            PlantGenus.Lathyrus,
            PlantGenus.Aster,
            PlantGenus.Malva
        }

    };
    //TODO: add plantTypes & structureTypes
    //TODO: add species matching style
    
    public static List<GardenStyle> GetAll()
    {
        return new List<GardenStyle>()
        {
            ModernAndMinimal, EnglishCountry, Cottage
        };
    }
}