using System.Drawing;

namespace Greenmaster_ASP.Helpers;

public static class ImageValidator
{
    /// <summary>
    /// Validates if given byte array can be an Image object.
    /// </summary>
    /// <param name="bytes">The byte array which potentially represents image-data.</param>
    /// <returns>true if valid, false if not</returns>
    public static bool IsValidImage(byte[] bytes)
    {
        try {
            using(MemoryStream ms = new MemoryStream(bytes))
                Image.FromStream(ms);
        }
        catch (ArgumentException) {
            return false;
        }
        return true; 
    }
}