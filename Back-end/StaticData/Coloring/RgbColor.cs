using System.ComponentModel.DataAnnotations;
using System.Drawing;
using JetBrains.Annotations;

namespace StaticData.Coloring;

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
        [Range(0,255)]
        public int Red { get; }

        /// <summary>
        /// Gets or sets the green component. Values from 0 to 255.
        /// </summary>
        [Range(0,255)]
        public int Green { get; }

        /// <summary>
        /// Gets or sets the blue component. Values from 0 to 255.
        /// </summary>
        [Range(0,255)]
        public int Blue { get; }

        /// <summary>
        /// Gets or sets the alpha component. Values from 0 to 255.
        /// </summary>
        [Range(0,255)]
        public int Alpha { get; }
        

        public override string ToString()
        {
            return $@"rgb({Red}, {Green}, {Blue})";
        }

        [UsedImplicitly]
        public RgbColor ToRgbColor()
        {
            return this;
        }

        public override bool Equals(object obj)
        {
            var equal = false;

            if (obj is RgbColor color)
            {
                if (Red == color.Red && Blue == color.Blue && Green == color.Green)
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