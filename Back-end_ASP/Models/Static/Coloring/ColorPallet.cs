using System.Drawing;

namespace Greenmaster_ASP.Models.Static.Coloring;

public static class ColorPallet
{
    public static Color[] Colors()
    {
        var colors = new List<Color>();
        colors.AddRange(ColorWheel.Colors());
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