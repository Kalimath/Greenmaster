using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using StaticData.Coloring;
using StaticData.Geographic;
using StaticData.Gradation;
using StaticData.Object.Organic;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Examples;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class SpecieExamples 
{
    public static readonly Specie Strelitzia = new()
    {
        Id = 1,
        Genus = PlantGenus.Strelitzia,
        Species = "Reginae",
        Cultivar = "",
        CommonNames = "Bird of paradise,Paradijsvogelbloem",
        Description = "some text.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        Shape = Shape.Vase,
        Cycle = Lifecycle.Perennial,
        Sunlight = Amount.Average,
        Water = Amount.Little,
        Climate = ClimateType.Tropical,
        MinimalTemperature = 10,
        MaxHeight = 2.5,
        MaxWidth = 0.75,
        BloomPeriod = new[]
        {
            Month.May, 
            Month.June, 
            Month.July, 
            Month.August,
            Month.September, 
            Month.October
        },
        PollinatingFlowers = false,
        IsFragrant = false,
        IsPoisonous = true,
        MutualisticGenera = Array.Empty<PlantGenus>(),
        FlowerColors = new[] { Color.Blue, Color.Orange },
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Papaver = new()
    {
        Id = 2,
        Genus = PlantGenus.Papaver,
        Species = "Orientale",
        Cultivar = "Catherina",
        CommonNames = "Eastern poppy, Oosterse papaver",
        Description = "Beautiful straight plant",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        Shape = Shape.Columnar,
        Cycle = Lifecycle.Annual,
        Sunlight = Amount.Many,
        Water = Amount.Little,
        Climate = ClimateType.Temperate,
        MinimalTemperature = -2,
        MaxHeight = 1,
        MaxWidth = 0.25,
        BloomPeriod = new[] { Month.May, Month.June },
        PollinatingFlowers = true,
        IsFragrant = false,
        IsPoisonous = false,
        MutualisticGenera =  new[] { PlantGenus.Aster},
        FlowerColors = new[] { Color.Pink },
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Aster = new()
    {
        Id = 3,
        Genus = PlantGenus.Aster,
        Species = "Maritimus",
        CommonNames = "Gele zeeaster",
        Description = "Een licht vorstgevoelige verhoutende vaste plant die bij ons eenjarige gekweekt wordt. " +
                      "Kan dus overgehouden worden en het jaar nadien terug in de border uitgeplant worden.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        Shape = Shape.NotSet,
        Cycle = Lifecycle.Annual,
        Sunlight = Amount.Many,
        Water = Amount.Average,
        Climate = ClimateType.Mediterranean,
        MinimalTemperature = -2,
        MaxHeight = 0.2,
        MaxWidth = 0.2,
        BloomPeriod = new []
        {
            Month.May, 
            Month.June, 
            Month.July, 
            Month.August,
            Month.September
        },
        PollinatingFlowers = true,
        IsFragrant = false,
        IsPoisonous = false,
        MutualisticGenera =  new[] { PlantGenus.Papaver},
        FlowerColors = new[] { Color.Yellow },
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Lime = new()
    {
        Id = 4,
        Genus = PlantGenus.Citrus,
        Species = "Aurantifolia",
        Cultivar = "Lime",
        CommonNames = "Limoen, Mexican Lime",
        Description = "Its trunk, which rarely grows straight, has many branches, and they often originate quite far down on the trunk. The leaves are ovate, 25–90 mm long, resembling orange leaves (the scientific name aurantifolia refers to this resemblance to the leaves of the orange, Citrus aurantium). The flowers are 25 mm (1 in) in diameter, are yellowish white with a light purple tinge on the margins.",
        PlantTypeId = ObjectTypeExamples.Tree.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Round,
        Sunlight = Amount.Many,
        Water = Amount.Average,
        Climate = ClimateType.Tropical,
        MinimalTemperature = 5,
        MaxHeight = 4,
        MaxWidth = 2.5,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new Month[]
        {
            //all months
            Month.January,
            Month.February,
            Month.March,
            Month.April,
            Month.May,
            Month.June,
            Month.July,
            Month.August,
            Month.September,
            Month.October,
            Month.November,
            Month.December
        },
        FlowerColors = new[]
        {
            Color.White
        },
        IsFragrant = true,
        PollinatingFlowers = true,
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie Lemon = new()
    {
        Id = 5,
        Genus = PlantGenus.Citrus,
        Species = "Limon",
        Cultivar = string.Empty,
        CommonNames = "Citroen boom, Lemon tree",
        Description = "Evergreen spreading bush or small tree, 3–6 metres (10–20 feet) high if not pruned. Its young oval leaves have a decidedly reddish tint; later they turn green. In some varieties the young branches of the lemon are angular; some have sharp thorns at the axils of the leaves.",
        PlantTypeId = ObjectTypeExamples.Tree.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Round,
        Sunlight = Amount.Many,
        Water = Amount.Average,
        Climate = ClimateType.Tropical,
        MinimalTemperature = 5,
        MaxHeight = 4,
        MaxWidth = 2.5,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new[]
        {
            //all months
            Month.January,
            Month.February,
            Month.March,
            Month.April,
            Month.May,
            Month.June,
            Month.July,
            Month.August,
            Month.September,
            Month.October,
            Month.November,
            Month.December
        },
        FlowerColors = new[]
        {
            Color.White
        },
        IsFragrant = true,
        PollinatingFlowers = true,
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie LavenderA = new()
    {
        Id = 6,
        Genus = PlantGenus.Lavandula,
        Species = "Stoechas",
        Cultivar = string.Empty,
        CommonNames = "Kuiflavendel, Lemon tree",
        Description = "evergreen shrub that usually grows to between 30 and 100 cm tall. The inflorescence is crowned by a mass of purple elongated ovoid bracts about 5 cm long. Lower flowers form a tight rectangle in cross-section. The upper of the five teeth has a wrong-heart-shaped appendage. The crown is blackish-violet, up to 8 mm long and indistinct two-lipped. The flowers, which appear in late spring and early summer, are pink to purple, produced on spikes 2 cm long at the top of slender, leafless stems 10–30 cm (4–12 in) long; each flower is subtended by a bract 4–8 mm long. At the top of the spike are a number of much larger, sterile bracts (no flowers between them), 10–50 mm long and bright lavender purple (rarely white). It blooms in spring and early summer, from the month of March in its native habitat, depending on the climate in which it grows.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.NotSet,
        Sunlight = Amount.Many,
        Water = Amount.Little,
        Climate = ClimateType.Mediterranean,
        MinimalTemperature = 5,
        MaxHeight = 1,
        MaxWidth = 0.6,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new[]
        {
            Month.July,
            Month.August,
            Month.September,
            Month.October
        },
        FlowerColors = new[]
        {
            Color.BlueViolet,
            Color.Violet
        },
        IsFragrant = true,
        PollinatingFlowers = true,
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie LavenderB = new()
    {
        Id = 7,
        Genus = PlantGenus.Lavandula,
        Species = "Angustifolia",
        Cultivar = string.Empty,
        CommonNames = "Echte lavendel,Common lavender",
        Description = "A flowering plant in the family Lamiaceae, native to the Mediterranean (Spain, France, Italy, Croatia etc.).",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.NotSet,
        Sunlight = Amount.Many,
        Water = Amount.Little,
        Climate = ClimateType.Mediterranean,
        MinimalTemperature = -5,
        MaxHeight = 0.6,
        MaxWidth = 0.6,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new[]
        {
            Month.July,
            Month.August
        },
        FlowerColors = new[]
        {
            Color.BlueViolet
        },
        IsFragrant = true,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie Impatiens = new()
    {
        Id = 8,
        Genus = PlantGenus.Impatiens,
        Species = "Walleriana",
        Cultivar = string.Empty,
        CommonNames = "Vlijtig liesje,Busy Lizzie",
        Description = "A species of the genus Impatiens, native to eastern Africa from Kenya to Mozambique.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.NotSet,
        Sunlight = Amount.Average,
        Water = Amount.Average,
        Climate = ClimateType.Mediterranean,
        MinimalTemperature = 10,
        MaxHeight = 0.4,
        MaxWidth = 0.4,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new[]
        {
            Month.May,
            Month.June,
            Month.July,
            Month.August,
            Month.September
        },
        FlowerColors = new[]
        {
            Color.White,
            Color.Orange,
            Color.Pink,
            Color.Red,
            Color.Blue
        },
        IsFragrant = false,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
    public static readonly Specie Syringa = new()
    {
        Id = 9,
        Genus = PlantGenus.Syringa,
        Species = "Vulgaris",
        Cultivar = "Louis Spaeth",
        CommonNames = "Sering,Lilac",
        Description = "A species of flowering plant in the olive family Oleaceae, native to the Balkan Peninsula, where it grows on rocky hills. " +
                      "Grown in spring for its scented flowers, this large shrub or small tree is widely cultivated and has been naturalized in parts of Europe, Asia and North America. " +
                      "It is not regarded as an aggressive species. It is found in the wild in widely scattered sites, usually in the vicinity of past or present human habitations.",
        PlantTypeId = ObjectTypeExamples.LargeShrub.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Irregular,
        Sunlight = Amount.Average,
        Water = Amount.Average,
        Climate = ClimateType.Temperate,
        MinimalTemperature = -25,
        MaxHeight = 6,
        MaxWidth = 1,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new[]
        {
            Month.April,
            Month.May
        },
        FlowerColors = new[]
        {
            Color.White,
            Color.Orange,
            Color.Pink,
            Color.Red,
            Color.Blue
        },
        IsFragrant = true,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
    public static readonly Specie Heliotropium = new()
    {
        Id = 10,
        Genus = PlantGenus.Heliotropium,
        Species = "Arborescens",
        Cultivar = "",
        CommonNames = "Vanillebloem,zonnewende,Garden heliotrope",
        Description = "A species of flowering plant in the borage family Boraginaceae, native to Bolivia, Colombia, and Peru. " +
                      "Growing to 1.2 m tall and broad, it is a bushy, evergreen, short-lived shrub with dense clusters of bright purple flowers, notable for their intense, rather vanilla-like fragrance.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        IsPoisonous = true,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Irregular,
        Sunlight = Amount.Average,
        Water = Amount.Average,
        Climate = ClimateType.Temperate,
        MinimalTemperature = 5,
        MaxHeight = 1.2,
        MaxWidth = 1,
        MutualisticGenera = new PlantGenus[]
        {
        },
        BloomPeriod = new[]
        {
            //may until september
            Month.May,
            Month.June,
            Month.July,
            Month.August,
            Month.September
        },
        FlowerColors = new[]
        {
            Color.Indigo, 
            Color.Blue
        },
        IsFragrant = true,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie Fuchsia = new()
    {
        Id = 11,
        Genus = PlantGenus.Fuchsia,
        Species = "Regia",
        Cultivar = "",
        CommonNames = "Fuchsia",
        Description = "an evergreen supporting shrub about 1.5 to 3 meters tall, with slender, pendulous branches arising from the base of the trunk. " +
                      "Its leaves are simple, lanceolate in shape, usually have a reddish petiole, and are grouped in whorls." +
                      "Like the other species in this section, its flowers solitary or rarely in pairs, terminal and axillary, pendulous, and have the nectary fused to the base of the hypanthus (tube), which is cylindrical and generally not longer than the large sepals. open and red. " +
                      "The stamens are reddish, long, and extend beyond the corolla. Sepals red or rose. The petals are violet-fuchsia color. The fruit is a berry that comes from an ovary in a lower position.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Irregular,
        Sunlight = Amount.Average,
        Water = Amount.Average,
        Climate = ClimateType.Tropical,
        MinimalTemperature = 3,
        MaxHeight = 0.5,
        MaxWidth = 0.5,
        MutualisticGenera = new []
        {
            PlantGenus.Fuchsia,
            PlantGenus.Heliotropium,
            PlantGenus.Impatiens,
            PlantGenus.Begonia
        },
        BloomPeriod = new[]
        {
            //may until september
            Month.May,
            Month.June,
            Month.July,
            Month.August,
            Month.September
        },
        FlowerColors = new[]
        {
            Color.White,
            Color.Pink,
            Color.Red,
            Color.Purple
        },
        IsFragrant = false,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie Forsythia = new()
    {
        Id = 12,
        Genus = PlantGenus.Forsythia,
        Species = "x Intermedia",
        Cultivar = "GoldRausch",
        CommonNames = "Chinees klokje,Border forsythia",
        Description = "The shrub has an upright habit with arching branches and grows to 3 to 4 metres high. " +
                      "The opposite leaves turn yellowish or occasionally purplish in the autumn before falling. " +
                      "The bright yellow flowers are produced on one- to two-year-old growth and may be solitary or in racemes from 2 to 6.",
        PlantTypeId = ObjectTypeExamples.LargeShrub.Id,
        IsPoisonous = false,
        Cycle = Lifecycle.Biennial,
        Shape = Shape.Vase,
        Sunlight = Amount.Average,
        Water = Amount.Average,
        Climate = ClimateType.Temperate,
        MinimalTemperature = 3,
        MaxHeight = 2,
        MaxWidth = 1,
        MutualisticGenera = Array.Empty<PlantGenus>(),
        BloomPeriod = new[]
        {
            Month.February,
            Month.March,
            Month.April
        },
        FlowerColors = new[]
        {
            Color.Yellow
        },
        IsFragrant = false,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
    public static readonly Specie WisteriaA = new()
    {
        Id = 13,
        Genus = PlantGenus.Wisteria,
        Species = "Frutescens",
        Cultivar = "Amethyst Falls",
        CommonNames = "Blauwe regen,Border forsythia",
        Description = "produces wonderfully scented flowers from spring to early summer. " +
                      "Unlike traditional Wisteria varieties, Amethyst Falls begins to bloom on new wood during the first year of cultivation. " +
                      "No pruning is necessary, except to keep the plant somewhat in check.",
        PlantTypeId = ObjectTypeExamples.Climber.Id,
        IsPoisonous = true,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Irregular,
        Sunlight = Amount.Many,
        Water = Amount.Average,
        Climate = ClimateType.Temperate,
        MinimalTemperature = 3,
        MaxHeight = 5,
        MaxWidth = 3,
        MutualisticGenera = Array.Empty<PlantGenus>(),
        BloomPeriod = new[]
        {
            //may until september
            Month.May,
            Month.June,
            Month.July,
            Month.August,
            Month.September
        },
        FlowerColors = new[]
        {
            Color.Blue
        },
        IsFragrant = false,
        PollinatingFlowers = false,
        Image = Base64Examples.ImageSpecie
    };
        
    // ReSharper disable once ComplexConditionExpression
    public static readonly Specie Ginkgo = new()
    {
        Id = 14,
        Genus = PlantGenus.Ginkgo,
        Species = "Biloba",
        Cultivar = "",
        CommonNames = "Japanse notenboom,Tempelboom,Eendenpootboom,Maidenhair tree",
        Description = "Ginkgos are large trees, normally reaching a height of 20–35 m (66–115 ft), with some specimens in China being over 50 m (165 ft). " +
                      "The tree has an angular crown and long, somewhat erratic branches, and is usually deep-rooted and resistant to wind and snow damage. " +
                      "Young trees are often tall and slender, and sparsely branched; the crown becomes broader as the tree ages. " +
                      "A combination of resistance to disease, insect-resistant wood, and the ability to form aerial roots and sprouts makes ginkgos durable, with some specimens claimed to be more than 2,500 years old.",
        PlantTypeId = ObjectTypeExamples.Tree.Id,
        IsPoisonous = true,
        Cycle = Lifecycle.Perennial,
        Shape = Shape.Irregular,
        Sunlight = Amount.Average,
        Water = Amount.Average,
        Climate = ClimateType.Temperate,
        MinimalTemperature = -15,
        MaxHeight = 25,
        MaxWidth = 5,
        MutualisticGenera = Array.Empty<PlantGenus>(),
        BloomPeriod = new[]
        {
            Month.April,
            Month.May
        },
        FlowerColors = new[]
        {
            Color.Green
        },
        IsFragrant = false,
        PollinatingFlowers = true,
        Image = FileConverter.ToBase64(@"C:\Users\mathi\RiderProjects\Greenmaster_ASP\Back-end\Greenmaster.Core\Examples\Images\ginkgo.png")
    };

    public static List<Specie> GetAll()
    {
        return new List<Specie>()
        {
            Strelitzia,
            Papaver, 
            Aster,
            Lime,
            Lemon,
            LavenderA,
            LavenderB,
            Impatiens,
            Syringa,
            Heliotropium,
            Fuchsia,
            Forsythia,
            WisteriaA,
            Ginkgo
        };
    }
}