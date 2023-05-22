namespace Greenmaster_ASP.Models.Static;

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
        Color.BlueGreen,
        Color.OrangeRed,
        Color.OrangeYellow,
        Color.BlueViolet,
        Color.Purple
    };

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
        Color.OrangeYellow,
        Color.Yellow,
        Color.YellowGreen,
    };
    
    public static Color[] ColdColors => new[]
    {
        Color.Green,
        Color.BlueGreen,
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
        var secondaryColor = primaryColors switch
        {
            (Color.Yellow, Color.Red) => Color.Orange,
            (Color.Yellow, Color.Blue) => Color.Green,
            (Color.Blue, Color.Red) => Color.Violet,
            _ => Color.NotSpecified
        };

        return secondaryColor;
    }

    public static Color TertiaryColor(Tuple<Color, Color> primaryWithSecondary)
    {
        var tertiary = primaryWithSecondary switch
        {
            (Color.Yellow, Color.Green) => Color.YellowGreen,
            (Color.Yellow, Color.Orange) => Color.OrangeYellow,
            (Color.Orange, Color.Red) => Color.OrangeRed,
            (Color.Red, Color.Violet) => Color.Purple,
            (Color.Violet, Color.Blue) => Color.BlueViolet,
            _ => Color.NotSpecified
        };
        return tertiary;
    }

    // ReSharper disable once FlagArgument
    public static Color ComplementaryColor(this Color color)
    {
        if (color.IsWheelColor())
        {
            return color.IsWarmColor() 
                ? ColdColors[Array.FindIndex(WarmColors, row => row.Equals(color))] 
                : WarmColors[Array.FindIndex(ColdColors, row => row.Equals(color))];
        }
        return Color.NotSpecified;
    }
}