using Greenmaster_ASP.Models.Static;

namespace Greenmaster_ASP.Models.Extensions;

public static class ColorExtensions
{
    public static string GetName(this Color color)
    {
        return Enum.GetName(typeof(Color), color) ?? throw new ArgumentException();
    }
    public static IEnumerable<string> GetNames(this IEnumerable<Color> colors)
    {
        var list = colors.ToList();
        return list.Select(color => color.GetName());
    }
}