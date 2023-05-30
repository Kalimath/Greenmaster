namespace Greenmaster.Core.Helpers;

public static class FileConverter
{
    /// <summary>
    /// Returns file from path as a base64-string.
    /// </summary>
    /// <param name="path">The path of to the file that needs to be converted.</param>
    /// <returns>The converted base64-string.</returns>
    public static string ToBase64(string path)
    {
        var bytes = File.ReadAllBytes(path);
        return Convert.ToBase64String(bytes);
    }
    
    /*public static string ToResizedBase64(string path, int height, int width)
    {
        throw new NotImplementedException();
    }*/
}