namespace Greenmaster_ASP.Helpers;

public static class FormFileConverter
{
    /// <summary>
    /// Converts given IFormFile to a string in base64 format.
    /// </summary>
    /// <param name="file">The Image object which will be converted.</param>
    /// <returns>The converted base64-string.</returns>
    public static async Task<string> ToBase64(IFormFile file)
    {
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();
            return Convert.ToBase64String(bytes);
        }
    }

    /// <summary>
    /// Converts given base64-string to an IFormFile object.
    /// </summary>
    /// <param name="base64String">The base64 string which will be converted.</param>
    /// <returns>The converted IFormFile.</returns>
    public static IFormFile FromBase64(string base64String)
    {
        StringValidator.ValidateStringAndBase64(base64String);
        var bytes = Convert.FromBase64String(base64String);
        var stream = new MemoryStream(bytes);
        const string fileName = "test_image_file";
        return new FormFile(stream, 0, stream.Length, fileName, Path.GetFileNameWithoutExtension(fileName) + ".jpg");
    }
}