using System.Drawing;

namespace StaticData.Coloring;

public static class ColorPallet
{
    /// <summary>
    /// Returns brown, all primary, secondary, tertiary and achromatic colors.
    /// </summary>
    public static Color[] Colors()
    {
        var colors = new List<Color>();
        colors.AddRange(ColorWheel.Colors());
        colors.AddRange(GetAchromaticColors());
        colors.Add(Color.Brown);
        
        return colors.ToArray();
    }
    
    /// <summary>
    /// Returns brown, all primary, secondary and achromatic colors.
    /// </summary>
    public static Color[] BaseColors()
    {
        var colors = new List<Color>();
        colors.AddRange(ColorWheel.PrimaryAndSecondaryColors());
        colors.AddRange(GetAchromaticColors());
        colors.Add(Color.Brown);
        
        return colors.ToArray();
    }
    
    
    public static IEnumerable<Color> GetAchromaticColors()
    {
        return new[]
        {
            Color.White,
            Color.LightGray,
            Color.Gray,
            Color.Black
        };
    }

    public static IEnumerable<Color> Near(Color color)
    {
        return ColorWheel.AdjacentColors(color);
    }

    public static IEnumerable<Color> GetComposedColors() => Colors().Except(ColorWheel.PrimaryColors);
}