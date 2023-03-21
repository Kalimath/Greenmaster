using System.Diagnostics.CodeAnalysis;
using System.Drawing;

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
}