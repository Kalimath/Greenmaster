using Greenmaster_ASP.Models;

namespace Greenmaster_ASP.Helpers;

public static class StringValidator
{
    /// <summary>
    /// Validates if given string is in base64 format.
    /// </summary>
    /// <param name="stringBase64">The string to validate.</param>
    /// <returns>true or false</returns>
    public static bool IsBase64String(string stringBase64)
    {
        var buffer = new Span<byte>(new byte[stringBase64.Length]);
        return Convert.TryFromBase64String(stringBase64, buffer , out var bytesParsed);
    }

    /// <summary>
    /// Validates if given string is not null, empty or whitespace.
    /// </summary>
    /// <param name="str">The string to validate.</param>
    /// <returns>true or false</returns>
    public static bool IsValidString(string str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }

    /// <summary>
    /// Validates if given string is in base64 format, and not null, empty or whitespace.
    /// </summary>
    /// <param name="stringBase64">The string to validate.</param>
    /// <returns>true or false</returns>
    public static bool IsValidAndBase64String(string stringBase64)
    {
        var isValidString = IsValidString(stringBase64);
        var isBase64String = IsBase64String(stringBase64);
        return isValidString && isBase64String;
    }
    
    /// <summary>
    /// Validates if given is valid string and in base64 format.
    /// </summary>
    /// <param name="stringBase64">The string to validate.</param>
    /// <Throws>ArgumentException when string invalid</Throws>
    /// <Throws>FormatException when format invalid</Throws>
    public static void ValidateStringAndBase64(string stringBase64)
    {
        if (!IsValidString(stringBase64))
            throw new ArgumentException(nameof(stringBase64));
        if (!IsBase64String(stringBase64))
        {
            throw new FormatException(nameof(stringBase64));
        }
    }
}