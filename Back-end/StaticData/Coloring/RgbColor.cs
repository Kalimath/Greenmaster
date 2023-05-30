using System.Drawing;
using JetBrains.Annotations;

namespace StaticData.Coloring;

 /// <summary>
    /// Represents a RGB color space.
    /// http://en.wikipedia.org/wiki/HSV_color_space
    /// </summary>
    public sealed class RgbColor
    {
        public RgbColor(
            int red,
            int green,
            int blue,
            int alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        /// <summary>
        /// Gets or sets the red component. Values from 0 to 255.
        /// </summary>
        [UsedImplicitly]
        public int Red { get; }

        /// <summary>
        /// Gets or sets the green component. Values from 0 to 255.
        /// </summary>
        [UsedImplicitly]
        public int Green { get; }

        /// <summary>
        /// Gets or sets the blue component. Values from 0 to 255.
        /// </summary>
        [UsedImplicitly]
        public int Blue { get; }

        /// <summary>
        /// Gets or sets the alpha component. Values from 0 to 255.
        /// </summary>
        [UsedImplicitly]
        public int Alpha { get; }

        [UsedImplicitly]
        public static RgbColor FromColor(
            Color color)
        {
            return ColorConverting.ColorToRgb(color);
        }

        [UsedImplicitly]
        public static RgbColor FromRgbColor(
            RgbColor color)
        {
            return new(color.Red, color.Green, color.Blue, color.Alpha);
        }

        [UsedImplicitly]
        public static RgbColor FromHsbColor(
            HsbColor color)
        {
            return color.ToRgbColor();
        }

        [UsedImplicitly]
        public static RgbColor FromHslColor(
            HslColor color)
        {
            return color.ToRgbColor();
        }

        public override string ToString()
        {
            return Alpha < 255 ? $@"rgba({Red}, {Green}, {Blue}, {Alpha / 255d})" : $@"rgb({Red}, {Green}, {Blue})";
        }

        public Color ToColor()
        {
            return ColorConverting.RgbToColor(this);
        }

        [UsedImplicitly]
        public RgbColor ToRgbColor()
        {
            return this;
        }

        [UsedImplicitly]
        public HsbColor ToHsbColor()
        {
            return ColorConverting.RgbToHsb(this);
        }

        public HslColor ToHslColor()
        {
            return ColorConverting.RgbToHsl(this);
        }

        public override bool Equals(
            object obj)
        {
            var equal = false;

            if (obj is RgbColor color)
            {
                var rgb = color;

                if (Red == rgb.Red && Blue == rgb.Blue && Green == rgb.Green)
                {
                    equal = true;
                }
            }

            return equal;
        }

        public override int GetHashCode()
        {
            return $@"R:{Red}-G:{Green}-B:{Blue}-A:{Alpha}".GetHashCode();
        }
    }