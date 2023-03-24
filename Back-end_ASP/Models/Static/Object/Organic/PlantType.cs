using System.ComponentModel.DataAnnotations;

namespace Greenmaster_ASP.Models.Static.Object.Organic;

public class PlantType
{
    public string Name { get; set; }
    public Permeability Canopy { get; set; }
    public bool AllowAsUndergrowth { get; set; }
    public string Description { get; set; }
    private PlantType(string name, bool allowAsUndergrowth, string description)
    {
        Name = name;
        AllowAsUndergrowth = allowAsUndergrowth;
        Description = description;
    }
    
    public static readonly PlantType Hedge = new PlantType("Hedge", false, "Hedges are rows of closely planted shrubs, and come in all shapes, styles and sizes.");
    public static readonly PlantType Tree = new PlantType("Tree", false, "Trees have a permanent woody structure – usually a single trunk and a network of branches. Some grow quite large, but there are plenty of smaller options too. Most offer an array of attractive features, including decorative foliage, flowers, fruits and bark. Some keep their leaves all year, while others are leafless over winter.");
    public static readonly PlantType Climber = new PlantType("Climber", true, "These plants clothe walls and supports in foliage and flowers. Climbers cling on using tendrils, twining stems, stem roots or sticky pads, while wall shrubs need to be tied to supports. Plants can be large and vigorous or neat and compact, some are evergreen retaining their foliage all year, while others are deciduous and lose their leaves over winter. ");
    public static readonly PlantType SmallShrub = new PlantType("Small shrub (<2 metres)",  true, "Small shrubs have a permanent structure of woody stems. They come in all shapes, some holding onto their leaves all year, others losing them in autumn. As well as flowers in every possible hue, many shrubs have attractive foliage and fruits.");
    public static readonly PlantType LargeShrub = new PlantType("Large shrub (2-8 metres)",  true, "Large shrubs have a permanent structure of woody stems. They come in all shapes, some holding onto their leaves all year, others losing them in autumn. As well as flowers in every possible hue, many shrubs have attractive foliage, fruits and bark.");
    public static readonly PlantType Grass = new PlantType("Grass", true, "Versatile, hardy and spectacular, bringing movement, texture and drama to gardens of all styles, nearly all year round.");
    public static readonly PlantType Fern = new PlantType("Fern", true, "Ferns can be large or small, often with elegantly arching, feathery foliage. The plants usually have a shuttlecock shape, with new growth unfurling from the centre. Deciduous types die down in winter, while evergreen and semi-evergreen have a year-round presence.");
    public static readonly PlantType Aquatic = new PlantType("Aquatic", true, "Aquatic and bog plants tend to be big and bold, lush and leafy, with brightly coloured flowers. Some aquatics spread out across the pond’s surface, while others grow vertically out of the water.");
    public static readonly PlantType Bulb = new PlantType("Bulb", true, "It includes a wide range of flower shapes, colours and sizes as this is a large and diverse group.");
    public static readonly PlantType Succulent = new PlantType("Succulent", false, "They come in a huge range of shapes, colours and forms, some covered in spines, others smooth or furry, some gently rounded, others angular and sculptural.");
    public static readonly PlantType Cactus = new PlantType("Cactus", false, "They come in a huge range of shapes, colours and forms, some covered in spines, others smooth or furry, some gently rounded, others angular and sculptural.");

    public static List<PlantType> GetAll()
    {
        return new List<PlantType>(){ Hedge,Tree,Climber,SmallShrub,LargeShrub,Grass,Fern,Aquatic,Bulb,Succulent,Cactus};
    }

    public static List<string> GetAllNames()
    {
        return GetAll().Select(type => type.Name).ToList();
    }

    public static PlantType GetByName(string name)
    {
        if (string.IsNullOrEmpty(name?.Trim()))
        {
            throw new ArgumentException(nameof(name));
        }
        var capitalisedName = char.ToUpper(name[0]) + name.Substring(1);
        if (!GetAllNames().Contains(capitalisedName))
        {
            throw new ArgumentOutOfRangeException(nameof(name));
        }

        return GetAll().First(type => type.Name == capitalisedName);
    }
}

public enum Permeability
{
    NotSet=0,
    Open=1,
    Partial=2,
    Closed=3
}