using System.Drawing;
using System.Net.Mime;

namespace eu.mbdevelopment.greenmaster.Domain.Shared.Validators;

public static class ImageValidator
{
    /// <summary>
    /// Validates if given byte array can be an Image object.
    /// </summary>
    /// <param name="bytes">The byte array which potentially represents image-data.</param>
    /// <returns>true if valid, false if not</returns>
    public static bool IsValidImage(byte[] bytes)
    {
        try
        {
            using MemoryStream ms = new MemoryStream(bytes);
            #pragma warning disable CA1416
            Image.FromStream(ms);
            #pragma warning restore CA1416
        }
        catch (ArgumentException) {
            return false;
        }
        return true; 
    }
}