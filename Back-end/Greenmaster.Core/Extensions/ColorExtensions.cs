﻿using System.Drawing;
using System.Reflection;

namespace Greenmaster.Core.Extensions;

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
        var complementary = color.ToKnownColor() switch
            {
                KnownColor.Black => Color.White,
                KnownColor.White => Color.Black,
                KnownColor.Red => Color.Green,
                KnownColor.Green => Color.Red,
                KnownColor.Blue => Color.Orange,
                KnownColor.Yellow => Color.Purple,
                KnownColor.Orange => Color.Blue,
                _ => Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
            };

        return complementary;
    }

    public static Color ToColor(this string colorName)
    {
        return Color.FromKnownColor(Enum.Parse<KnownColor>(colorName));
    }

    /// <summary>
    /// Convert a .NET Color to a hex string.
    /// </summary>
    /// <returns>null if invalid</returns>
    public static string ToHex(this Color color)
    {
        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }
}