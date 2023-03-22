namespace Greenmaster_ASP.Helpers;

public static class FormFileConverter
{
    public static async Task<string> ToBase64(IFormFile file)
    {
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();
            return Convert.ToBase64String(bytes);
        }
    }
}