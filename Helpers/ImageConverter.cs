using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Greenmaster_ASP.Helpers;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class ImageConverter
{
    public static byte[] ToByteArray(Image image)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms,image.RawFormat);
            return  ms.ToArray();
        }
    }
    
    public static string ToBase64(Image image)
    {
        //a single pixel (black) "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="
        byte[] imageArray = ToByteArray(image);
        return Convert.ToBase64String(imageArray);
        
    }
    
    public static Image FromBase64(string base64String)
    {
        //a single pixel (black) "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="
        byte[] bytes = Convert.FromBase64String(base64String);

        Image image;
        using var stream = new MemoryStream(bytes);
        image = Image.FromStream(stream);
        
        return image;
    }

    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Image Resize(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width,image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }
}