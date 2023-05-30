using static Greenmaster.Core.Helpers.ImageConverter;

namespace Greenmaster.Core.Tests.Helpers;

public class FromBase64Should
{
    [Fact]
    public void ThrowArgumentNullException_WhenStringNull()
    {
        Assert.Throws<ArgumentNullException>(
            () => { _ = FromBase64(null!); });
    }
    [Fact]
    public void ThrowArgumentException_WhenStringEmpty()
    {
        Assert.Throws<ArgumentException>(
            () => { _ = FromBase64(String.Empty); });
    }
    [Fact]
    public void ThrowArgumentException_WhenStringNotValidBase64String()
    {
        Assert.Throws<ArgumentException>(
            () => { _ = FromBase64("geueikej5646"); });
    }
}