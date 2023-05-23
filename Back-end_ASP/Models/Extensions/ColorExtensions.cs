using System.Drawing;
using System.Reflection;

namespace Greenmaster_ASP.Models.Extensions;

public static class ColorExtensions
{
    public static string GetName(this Color color)
    {
        var predefined = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
        var match = (from p in predefined where ((Color)p.GetValue(null, null)).ToArgb() == color.ToArgb() select (Color)p.GetValue(null, null));
        var matches = match.ToList();
        return matches.Any() ? matches.First().Name : string.Empty;
    }
    public static IEnumerable<string> GetNames(this IEnumerable<Color> colors)
    {
        var list = colors.ToList();
        return list.Select(color => color.GetName());
    }
    
    public static Color ComplementaryColor(this Color color)
    {
        return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);;
    }

    public static Color ToColor(this string colorName)
    {
        return Color.FromKnownColor(Enum.Parse<KnownColor>(colorName));
    }
}