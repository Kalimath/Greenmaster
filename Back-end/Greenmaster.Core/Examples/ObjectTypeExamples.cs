using Greenmaster.Core.Models;
using StaticData.Gradation;

namespace Greenmaster.Core.Examples;

public static class ObjectTypeExamples
{
    //PlantTypes
    public static readonly PlantType Hedge = new(Guid.NewGuid(), "Hedge", false,Permeability.Closed,
        "Hedges are rows of closely planted shrubs, and come in all shapes, styles and sizes.");

    public static readonly PlantType Tree = new(Guid.NewGuid(), "Tree", false,Permeability.Closed,
        "Trees have a permanent woody structure – usually a single trunk and a network of branches. Some grow quite large, but there are plenty of smaller options too. Most offer an array of attractive features, including decorative foliage, flowers, fruits and bark. Some keep their leaves all year, while others are leafless over winter.");

    public static readonly PlantType Climber = new(Guid.NewGuid(), "Climber", true,Permeability.Partial,
        "These plants clothe walls and supports in foliage and flowers. Climbers cling on using tendrils, twining stems, stem roots or sticky pads, while wall shrubs need to be tied to supports. Plants can be large and vigorous or neat and compact, some are evergreen retaining their foliage all year, while others are deciduous and lose their leaves over winter. ");

    public static readonly PlantType SmallShrub = new(Guid.NewGuid(), "Small shrub (<2 metres)", true,Permeability.Partial,
        "Small shrubs have a permanent structure of woody stems. They come in all shapes, some holding onto their leaves all year, others losing them in autumn. As well as flowers in every possible hue, many shrubs have attractive foliage and fruits.");

    public static readonly PlantType LargeShrub = new(Guid.NewGuid(), "Large shrub (2-8 metres)", true,Permeability.Partial,
        "Large shrubs have a permanent structure of woody stems. They come in all shapes, some holding onto their leaves all year, others losing them in autumn. As well as flowers in every possible hue, many shrubs have attractive foliage, fruits and bark.");

    public static readonly PlantType Grass = new(Guid.NewGuid(), "Grass", true,Permeability.NotSet,
        "Versatile, hardy and spectacular, bringing movement, texture and drama to gardens of all styles, nearly all year round.");

    public static readonly PlantType Fern = new(Guid.NewGuid(), "Fern", true,Permeability.Closed,
        "Ferns can be large or small, often with elegantly arching, feathery foliage. The plants usually have a shuttlecock shape, with new growth unfurling from the centre. Deciduous types die down in winter, while evergreen and semi-evergreen have a year-round presence.");

    public static readonly PlantType Aquatic = new(Guid.NewGuid(), "Aquatic", true,Permeability.Partial,
        "Aquatic and bog plants tend to be big and bold, lush and leafy, with brightly coloured flowers. Some aquatics spread out across the pond’s surface, while others grow vertically out of the water.");

    public static readonly PlantType Bulb = new(Guid.NewGuid(), "Bulb", true,Permeability.Partial,
        "It includes a wide range of flower shapes, colours and sizes as this is a large and diverse group.");

    public static readonly PlantType Succulent = new(Guid.NewGuid(), "Succulent", false,Permeability.NotSet,
        "They come in a huge range of shapes, colours and forms, some covered in spines, others smooth or furry, some gently rounded, others angular and sculptural.");

    public static readonly PlantType Cactus = new(Guid.NewGuid(), "Cactus", false,Permeability.Open,
        "They come in a huge range of shapes, colours and forms, some covered in spines, others smooth or furry, some gently rounded, others angular and sculptural.");

    //StructureTypes
    public static readonly StructureType SwimmingPool = new(Guid.NewGuid(), "Swimming pool");
    public static readonly StructureType Pond = new(Guid.NewGuid(), "Pond");
    public static readonly StructureType Garage = new(Guid.NewGuid(), "Garage");
    public static readonly StructureType Swing = new(Guid.NewGuid(), "Swing");
    public static readonly StructureType AnimalPen = new(Guid.NewGuid(), "Animal pen");
    public static readonly StructureType Shed = new(Guid.NewGuid(), "Shed");

    public static List<PlantType> GetAllPlantTypes()
    {
        return new List<PlantType>()
            { Hedge, Tree, Climber, SmallShrub, LargeShrub, Grass, Fern, Aquatic, Bulb, Succulent, Cactus };
    }

    public static List<StructureType> GetAllStructureTypes()
    {
        return new List<StructureType>() { SwimmingPool, Pond, Garage, Swing, AnimalPen, Shed };
    }
}