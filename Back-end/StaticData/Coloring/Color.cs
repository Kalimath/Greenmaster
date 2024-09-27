using System.ComponentModel.DataAnnotations;

namespace StaticData.Coloring;

public record Color
{
    public ColorName Name { get; }
    
    [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Invalid Format")]
    public string Hex { get; }
    public RgbColor Rgb { get; }
    
    public Color(ColorName name, string hex)
    {
        Name = name;
        Hex = ValidateHex(hex);
        Rgb = HexToRgb(hex);
    }

    private static string ValidateHex(string hex)
    {
        return hex.StartsWith("0x")? hex : throw new ArgumentException("Invalid hex color format", hex);
    }

    public static Color GetColor(string colorName)
    {
        return GetAll().FirstOrDefault(color => color.Name == Enum.Parse<ColorName>(colorName)) ?? throw new ArgumentOutOfRangeException(colorName ,"Invalid color name: color not found");
    }

    public Color(ColorName name, RgbColor rgb)
    {
        Name = name;
        Hex = RgbToHex(rgb);
        Rgb = rgb;
    }
    
    public static RgbColor HexToRgb(string hex)
    {
        var rgbInt = Convert.ToInt32("FFD700", 16);
        var red = (byte)((rgbInt >> 16) & 255);
        var green = (byte)((rgbInt >> 8) & 255);
        var blue = (byte)(rgbInt & 255);
        return new RgbColor(red, green, blue, 255);
    }

    public static string RgbToHex(RgbColor rgb) => $"{rgb.Red:X2}{rgb.Green:X2}{rgb.Blue:X2}";

    public override string ToString()
    {
        return $"Name: {Name}, Hex: {Hex}, RGB: {Rgb}";
    }
    
    //for all colors in ColorName enum
    public static Color Red = new(ColorName.Red, "0xFF0000");
    public static Color Green = new(ColorName.Green, "0x00FF00");
    public static Color Blue = new(ColorName.Blue, "0x0000FF");
    public static Color Yellow = new(ColorName.Yellow, "0xFFFF00");
    public static Color Cyan = new(ColorName.Cyan, "0x00FFFF");
    public static Color Magenta = new(ColorName.Magenta, "0xFF00FF");
    public static Color Orange = new(ColorName.Orange, "0xFFA500");
    public static Color Purple = new(ColorName.Purple, "0x800080");
    public static Color Lime = new(ColorName.Lime, "0x00FF00");
    public static Color Maroon = new(ColorName.Maroon, "0x800000");
    public static Color DarkTurquoise = new(ColorName.DarkTurquoise, "0x008B8B");
    public static Color DarkSlateGray = new(ColorName.DarkSlateGray, "0x2F4F4F");
    public static Color DarkGray = new(ColorName.DarkGray, "0xA9A9A9");
    public static Color DarkGreen = new(ColorName.DarkGreen, "0x006400");
    public static Color DarkKhaki = new(ColorName.DarkKhaki, "0xBDB76B");
    public static Color DarkMagenta = new(ColorName.DarkMagenta, "0x8B008B");
    public static Color DarkOliveGreen = new(ColorName.DarkOliveGreen, "0x556B2F");
    public static Color DarkOrange = new(ColorName.DarkOrange, "0xFF8C00");
    public static Color DarkOrchid = new(ColorName.DarkOrchid, "0x9932CC");
    public static Color DarkRed = new(ColorName.DarkRed, "0x8B0000");
    public static Color DarkSalmon = new(ColorName.DarkSalmon, "0xE9967A");
    public static Color DarkSeaGreen = new(ColorName.DarkSeaGreen, "0x8FBC8F");
    public static Color DarkViolet = new(ColorName.DarkViolet, "0x9400D3");
    public static Color LightYellow = new(ColorName.LightYellow, "0xFFFFE0");
    public static Color DeepPink = new(ColorName.DeepPink, "0xFF1493");
    public static Color DeepSkyBlue = new(ColorName.DeepSkyBlue, "0x00BFFF");
    public static Color DimGray = new(ColorName.DimGray, "0x696969");
    public static Color DodgerBlue = new(ColorName.DodgerBlue, "0x1E90FF");
    public static Color Fuchsia = new(ColorName.Fuchsia, "0xFF00FF");
    public static Color Gainsboro = new(ColorName.Gainsboro, "0xDCDCDC");
    public static Color GhostWhite = new(ColorName.GhostWhite, "0xF8F8FF");
    public static Color Gold = new(ColorName.Gold, "0xFFD700");
    public static Color White = new(ColorName.White, "0xFFFFFF");
    public static Color Gray = new(ColorName.Gray, "0x808080");
    public static Color Brown = new(ColorName.Green, "0xA52A2A");
    public static Color LightGray = new(ColorName.LightGray, "0xD3D3D3");
    public static Color Black = new(ColorName.Black, "0x000000");
    public static Color Turquoise = new(ColorName.Turquoise, "0x40E0D0");
    public static Color BlueViolet = new(ColorName.BlueViolet, "0x8A2BE2");
    public static Color Crimson = new(ColorName.Crimson, "0xDC143C");
    public static Color DarkCyan = new(ColorName.DarkCyan, "0x008B8B");
    public static Color DarkGoldenrod = new(ColorName.DarkGoldenrod, "0xB8860B");
    public static Color Violet = new(ColorName.Violet, "0x8A2BE2");
    public static Color Firebrick = new(ColorName.Firebrick, "0xB22222");
    public static Color ForestGreen = new(ColorName.ForestGreen, "0x228B22");
    public static Color Goldenrod = new(ColorName.Goldenrod, "0xDAA520");
    public static Color OrangeRed = new(ColorName.OrangeRed, "0xFF4500");
    public static Color LightCoral = new(ColorName.LightCoral, "0xF08080");
    public static Color YellowGreen = new(ColorName.YellowGreen, "0x9ACD32");
    public static Color Indigo = new(ColorName.Indigo, "0x4B0082");
    public static Color Pink = new(ColorName.Pink, "0xFFC0CB");
    // public static Color SaddleBrown = new(ColorName.SaddleBrown, "0x8B4513");
    // public static Color SeaGreen = new(ColorName.SeaGreen, "0x2E8B57");
    // public static Color Chocolate = new(ColorName.Chocolate, "0xD2691E");
    // public static Color Sienna = new(ColorName.Sienna, "0xA0522D");
    // public static Color MediumVioletRed = new(ColorName.MediumVioletRed, "0xC71585");
    // public static Color LightSalmon = new(ColorName.LightSalmon, "0xFFA07A");
    // public static Color MediumSeaGreen = new(ColorName.MediumSeaGreen, "0x3CB371");





    public static Color[] GetAll()
    {
        return new[]
        {
            Red, Green, Blue, Yellow, Cyan, Magenta, Orange, Purple, Lime, Maroon, DarkTurquoise, DarkSlateGray, DarkGray, DarkGreen, DarkKhaki, DarkMagenta, DarkOliveGreen, DarkOrange, DarkOrchid, DarkRed, DarkSalmon, DarkSeaGreen, DarkViolet, LightYellow, DeepPink, DeepSkyBlue, DimGray, DodgerBlue, Fuchsia, Gainsboro, GhostWhite, Gold, White, Gray, Brown, LightGray, Black, Turquoise, BlueViolet, Crimson, DarkCyan, DarkGoldenrod, Violet, Firebrick, ForestGreen, Goldenrod, OrangeRed, LightCoral, YellowGreen
        };
    }

    public string GetHtmlHex()
    {
        return "#" + Hex[2..];
    }
}