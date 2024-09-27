// ReSharper disable FlagArgument

using System.Drawing;
using Color = System.Drawing.Color;

namespace StaticData.Coloring;

public static class ColorWheel
{
    //Based on subtractive color synthesis

    public static Color[] PrimaryColors => new[]
    {
        Color.Red,
        Color.Yellow,
        Color.Blue
    };

    public static Color[] SecondaryColors => new[]
    {
        Color.Orange,
        Color.Violet,
        Color.Green
    };

    public static Color[] TertiaryColors => new[]
    {
        Color.YellowGreen,
        Color.Turquoise,
        Color.OrangeRed,
        Color.Goldenrod,
        Color.BlueViolet,
        Color.Purple
    };

    /// <summary>
    /// Returns all primary, secondary, tertiary colors.
    /// </summary>
    public static Color[] Colors()
    {
        var wheelColors = new List<Color>();

        wheelColors.AddRange(PrimaryColors);
        wheelColors.AddRange(SecondaryColors);
        wheelColors.AddRange(TertiaryColors);

        return wheelColors.ToArray();
    }

    public static Color[] PrimaryAndSecondaryColors()
    {
        var wheelColors = new List<Color>();

        wheelColors.AddRange(PrimaryColors);
        wheelColors.AddRange(SecondaryColors);

        return wheelColors.ToArray();
    }

    public static Color[] WarmColors => new[]
    {
        Color.Red,
        Color.OrangeRed,
        Color.Orange,
        Color.Goldenrod,
        Color.Yellow,
        Color.YellowGreen,
    };

    public static Color[] ColdColors => new[]
    {
        Color.Green,
        Color.Turquoise,
        Color.Blue,
        Color.BlueViolet,
        Color.Violet,
        Color.Purple
    };

    public static bool IsWarmColor(this Color color) => WarmColors.Contains(color);

    public static bool IsColdColor(this Color color) => ColdColors.Contains(color);

    public static bool IsPrimaryColor(this Color color) => PrimaryColors.Contains(color);

    public static bool IsSecondaryColor(this Color color) => SecondaryColors.Contains(color);

    public static bool IsTertiaryColor(this Color color) => TertiaryColors.Contains(color);

    public static bool IsWheelColor(this Color color) => Colors().Contains(color);

    public static Color SecondaryColor(Tuple<Color, Color> primaryColors)
    {
        var secondaryColor = ToColorNameTuple(primaryColors) switch
        {
            (ColorName.Red, ColorName.Yellow) => Color.Orange,
            (ColorName.Red, ColorName.Blue) => Color.Violet,
            (ColorName.Blue, ColorName.Yellow) => Color.Green,
            _ => throw new ArgumentOutOfRangeException(nameof(primaryColors),
                "Given primary colors should be red/yellow/blue")
        };
        
        return secondaryColor;
    }

    public static Color TertiaryColor(Tuple<Color, Color> primaryWithSecondary)
    {
        var knownColors = ToColorNameTuple(primaryWithSecondary);

        var tertiaryColor = knownColors switch
        {
            (ColorName.Red, ColorName.Orange) => Color.OrangeRed,
            (ColorName.Yellow, ColorName.Orange) => Color.Goldenrod,
            (ColorName.Yellow, ColorName.Green) => Color.YellowGreen,
            (ColorName.Green, ColorName.Blue) => Color.Turquoise,
            (ColorName.Blue, ColorName.Violet) => Color.BlueViolet,
            (ColorName.Red, ColorName.Violet) => Color.Purple,
            _ => throw new ArgumentOutOfRangeException(nameof(primaryWithSecondary),
                "Given primary color is not red/yellow/blue color")
        };
        return tertiaryColor;
    }
    
    public static Color[] AdjacentColors(Color color)
    {
        if (color.IsPrimaryColor())
            return ColorsAdjacentToPrimary(color);

        return color.IsSecondaryColor() ? ColorsAdjacentToSecondary(color) : ColorsAdjacentToTertiary(color);
    }

    private static Color[] ColorsAdjacentToTertiary(Color color)
    {
        Color[] adjacentColors = color.Name switch
        {
            ColorName.OrangeRed => new[] { Color.Red, Color.Orange },
            ColorName.Goldenrod => new[] { Color.Yellow, Color.Orange },
            ColorName.BlueViolet => new[] { Color.Blue, Color.Violet },
            ColorName.Purple => new[] { Color.Red, Color.Violet },
            ColorName.YellowGreen => new[] { Color.Yellow, Color.Green },
            ColorName.Turquoise => new[] { Color.Blue, Color.Green },
            _ => throw new ArgumentOutOfRangeException(nameof(color), color,
                "Can not return tertiary adjacent colors when not a tertiary color")
        };
        return adjacentColors;
    }

    private static Color[] ColorsAdjacentToSecondary(Color color)
    {
        var adjacentColors = color.Name switch
        {
            ColorName.Orange => new[] { Color.OrangeRed, Color.Goldenrod },
            ColorName.Violet => new[] { Color.BlueViolet, Color.Purple },
            ColorName.Green => new[] { Color.YellowGreen, Color.Turquoise },
            _ => throw new ArgumentOutOfRangeException(nameof(color), color,
                "Can not return secondary adjacent colors when not a secondary color")
        };
        return adjacentColors;
    }

    private static Color[] ColorsAdjacentToPrimary(Color color)
    {
        var adjacentColors = color.Name switch
        {
            ColorName.Blue => new[] { Color.Turquoise, Color.BlueViolet },
            ColorName.Red => new[] { Color.OrangeRed, Color.Purple },
            ColorName.Yellow => new[] { Color.YellowGreen, Color.Goldenrod },
            _ => throw new ArgumentOutOfRangeException(nameof(color), color,
                "Can not return primary adjacent colors when not a primary color")
        };
        return adjacentColors;
    }

    private static Tuple<ColorName, ColorName> ToColorNameTuple(Tuple<Color, Color> colorPair)
    {
        return new Tuple<ColorName, ColorName>(colorPair.Item1.Name, colorPair.Item2.Name);
    }
}