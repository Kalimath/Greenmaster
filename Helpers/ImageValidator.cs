using System.Drawing;

namespace Greenmaster_ASP.Tests.Helpers;

public static class ImageValidator
{
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