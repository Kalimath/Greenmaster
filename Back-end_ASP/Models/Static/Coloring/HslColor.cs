using System.Drawing;
using JetBrains.Annotations;

namespace Greenmaster_ASP.Models.Static.Coloring;

/// <summary>
/// Represents a HSL color space.
/// http://en.wikipedia.org/wiki/HSV_color_space
/// </summary>
public sealed class HslColor
{
    public HslColor(
        double hue,
        double saturation,
        double light,
        int alpha)
    {
        PreciseHue = hue;
        PreciseSaturation = saturation;
        PreciseLight = light;
        Alpha = alpha;
    }

    public HslColor(
        int hue,
        int saturation,
        int light,
        int alpha)
    {
        PreciseHue = hue;
        PreciseSaturation = saturation;
        PreciseLight = light;
        Alpha = alpha;
    }

    /// <summary>
    /// Gets the hue. Values from 0 to 360.
    /// </summary>
    [UsedImplicitly]
    public int Hue => Convert.ToInt32(PreciseHue);

    /// <summary>
    /// Gets the precise hue. Values from 0 to 360.
    /// </summary>
    [UsedImplicitly]
    public double PreciseHue { get; }

    /// <summary>
    /// Gets the saturation. Values from 0 to 100.
    /// </summary>
    [UsedImplicitly]
    public int Saturation => Convert.ToInt32(PreciseSaturation);

    /// <summary>
    /// Gets the precise saturation. Values from 0 to 100.
    /// </summary>
    public double PreciseSaturation { get; }

    /// <summary>
    /// Gets the light. Values from 0 to 100.
    /// </summary>
    [UsedImplicitly]
    public int Light => Convert.ToInt32(PreciseLight);

    /// <summary>
    /// Gets the precise light. Values from 0 to 100.
    /// </summary>
    public double PreciseLight { get; }

    /// <summary>
    /// Gets the alpha. Values from 0 to 255
    /// </summary>
    public int Alpha { get; }

    public static HslColor FromColor(
        Color color)
    {
        return ColorConverting.RgbToHsl(
            ColorConverting.ColorToRgb(color));
    }

    [UsedImplicitly]
    public static HslColor FromRgbColor(
        RgbColor color)
    {
        return color.ToHslColor();
    }

    [UsedImplicitly]
    public static HslColor FromHslColor(
        HslColor color)
    {
        return new(
            color.PreciseHue,
            color.PreciseSaturation,
            color.PreciseLight,
            color.Alpha);
    }

    [UsedImplicitly]
    public static HslColor FromHsbColor(
        HsbColor color)
    {
        return FromRgbColor(color.ToRgbColor());
    }

    public override string ToString()
    {
        return Alpha < 255
            ? $@"hsla({Hue}, {Saturation}%, {Light}%, {Alpha / 255f})"
            : $@"hsl({Hue}, {Saturation}%, {Light}%)";
    }

    public Color ToColor()
    {
        return ColorConverting.HslToRgb(this).ToColor();
    }

    public RgbColor ToRgbColor()
    {
        return ColorConverting.HslToRgb(this);
    }

    public HslColor ToHslColor()
    {
        return this;
    }

    [UsedImplicitly]
    public HsbColor ToHsbColor()
    {
        return ColorConverting.RgbToHsb(ToRgbColor());
    }

    public override bool Equals(
        object obj)
    {
        var equal = false;

        if (obj is HslColor color)
        {
            var hsb = color;

            if (Math.Abs(Hue - hsb.PreciseHue) < double.Epsilon &&
                Math.Abs(Saturation - hsb.PreciseSaturation) < double.Epsilon &&
                Math.Abs(Light - hsb.PreciseLight) < double.Epsilon)
            {
                equal = true;
            }
        }

        return equal;
    }

    public override int GetHashCode()
    {
        return $@"H:{PreciseHue}-S:{PreciseSaturation}-L:{PreciseLight}".GetHashCode();
    }
}