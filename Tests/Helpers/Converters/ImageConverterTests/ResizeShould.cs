using System.Drawing;
using Greenmaster_ASP.Models.Examples;
using Xunit;
using ImageConverter = Greenmaster_ASP.Helpers.ImageConverter;

namespace Greenmaster_ASP.Tests.Helpers.Converters.ImageConverterTests;

public class ResizeShould
{
    
    [Fact]
    public void ReturnImageWithPassedHeight()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);
        const int height = 150;

        var resizedImage = ImageConverter.Resize(initialImage, 130, height);
        
        Assert.Equal(height, resizedImage.Height);
    }
    
    [Fact]
    public void ReturnImageWithPassedWidth()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);
        const int width = 130;
        
        var resizedImage = ImageConverter.Resize(initialImage, width, 150);
        
        Assert.Equal(width, resizedImage.Width);
    }
}