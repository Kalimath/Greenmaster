using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster_ASP.Models.Examples;
using Xunit;
using ImageConverter = Greenmaster_ASP.Helpers.ImageConverter;

namespace Greenmaster_ASP.Tests.Helpers.Converters.ImageConverterTests;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class ResizeShould
{
    private const int ValidImageWidth = 130;
    private const int ValidImageHeight = 150;

    [Fact]
    public void ThrowArgumentNullException_WhenImageNull()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);

        Assert.Throws<ArgumentNullException>(() => ImageConverter.Resize(null!, ValidImageWidth, ValidImageHeight));
    }
    
    [Fact]
    public void ReturnImage_WithPassedHeight()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);

        var resizedImage = ImageConverter.Resize(initialImage, ValidImageWidth, ValidImageHeight);
        
        Assert.Equal(ValidImageHeight, resizedImage.Height);
    }
    
    [Fact]
    public void ReturnImage_WithPassedWidth()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);
        
        var resizedImage = ImageConverter.Resize(initialImage, ValidImageWidth, ValidImageHeight);
        
        Assert.Equal(ValidImageWidth, resizedImage.Width);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenHeightLowerOrEqualToZero()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);

        Assert.Throws<ArgumentException>(() => ImageConverter.Resize(initialImage, ValidImageWidth, 0));
        Assert.Throws<ArgumentException>(() => ImageConverter.Resize(initialImage, ValidImageWidth, -1));
        Assert.Throws<ArgumentException>(() => ImageConverter.Resize(initialImage, ValidImageWidth, -15));
    }
    
    [Fact]
    public void ThrowArgumentException_WhenWidthLowerOrEqualToZero()
    {
        Image initialImage = new Bitmap(PathExamples.PathImageRendering);

        Assert.Throws<ArgumentException>(() => ImageConverter.Resize(initialImage, 0, ValidImageHeight));
        Assert.Throws<ArgumentException>(() => ImageConverter.Resize(initialImage, -1, ValidImageHeight));
        Assert.Throws<ArgumentException>(() => ImageConverter.Resize(initialImage, -15, ValidImageHeight));
    }
}