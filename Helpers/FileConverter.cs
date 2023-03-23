namespace Greenmaster_ASP.Helpers;

public static class FileConverter
{
    public static string ToBase64(string path)
    {
        var bytes = File.ReadAllBytes(path);
        return Convert.ToBase64String(bytes);
    }
    
    public static string ToResizedBase64(string path, int height, int width)
    {
        throw new NotImplementedException();
    }
}