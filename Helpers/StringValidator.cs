using Greenmaster_ASP.Models;

namespace Greenmaster_ASP.Helpers;

public static class StringValidator
{
    public static bool IsBase64String(string strBase64)
    {
        var buffer = new Span<byte>(new byte[strBase64.Length]);
        return Convert.TryFromBase64String(strBase64, buffer , out var bytesParsed);
    }

    public static bool IsValidString(string str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }

    public static bool IsValidAndBase64String(string strBase64)
    {
        var isValidString = IsValidString(strBase64);
        var isBase64String = IsBase64String(strBase64);
        return isValidString && isBase64String;
    }
    
    public static void ValidateImageBase64(string strBase64)
    {
        if (!IsValidString(strBase64))
            throw new ArgumentException(nameof(strBase64));
        if (!IsBase64String(strBase64))
        {
            throw new FormatException(nameof(strBase64));
        }
    }
}