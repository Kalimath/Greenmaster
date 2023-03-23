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

    public static IFormFile FromBase64(string base64String)
    {
        StringValidator.ValidateImageBase64(base64String);
        var bytes = Convert.FromBase64String(base64String);
        var stream = new MemoryStream(bytes);
        const string fileName = "test_image_file";
        return new FormFile(stream, 0, stream.Length, fileName, Path.GetFileNameWithoutExtension(fileName) + ".jpg");
    }
}