using StaticData.Coloring;

namespace Greenmaster.Core.Extensions;

public static class ColorExtensions
{
    
    public static Color ComplementaryColor(this Color color)
    {
        var complementary = color.Name switch
            {
                ColorName.Black => Color.White,
                ColorName.White => Color.Black,
                ColorName.Red => Color.Green,
                ColorName.Green => Color.Red,
                ColorName.Blue => Color.Orange,
                ColorName.Yellow => Color.Purple,
                ColorName.Orange => Color.Blue,
                _ => new Color(ColorName.Unspecified, new RgbColor(255 - color.Rgb.Red, 255 - color.Rgb.Green, 255 - color.Rgb.Blue, 255))
            };

        return complementary;
    }

    public static Color ToColor(this string hexValue)
    {
        return Color.GetAll().FirstOrDefault(color => color.Hex == hexValue) ?? throw new ArgumentOutOfRangeException(nameof(hexValue), hexValue, "Invalid hex color value");
    }

    public static string[] GetNames(this IEnumerable<Color> colors)
    {
        return colors.Select(color => color.Name.ToString()).ToArray();
    }
}