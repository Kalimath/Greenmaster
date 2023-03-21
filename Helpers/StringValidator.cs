namespace Greenmaster_ASP.Helpers;

public static class StringValidator
{
    public static bool IsBase64String(string base64)
    {
        var buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer , out var bytesParsed);
    }
}