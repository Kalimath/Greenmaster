using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.ViewModels;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.RenderingFactoryTests;

public class CreateRenderingShould
{
    [Fact]
    public void ThrowArgumentException_WhenImageIsNull()
    {
        Assert.Throws<ArgumentException>(() => _ = RenderingFactory.Create(new RenderingViewModel() { }));
    }
    [Fact]
    public void ThrowArgumentException_WhenImageIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => _ = RenderingFactory.Create(new RenderingViewModel() {ImageBase64 = String.Empty}));
    }
    [Fact]
    public void ThrowArgumentException_WhenImageIsWhiteSpace()
    {
        Assert.Throws<ArgumentException>(() => _ = RenderingFactory.Create(new RenderingViewModel() { ImageBase64 = "  "}));
    }
    [Fact]
    public void ThrowFormatException_WhenImageIsNotBase64()
    {
        Assert.Throws<FormatException>(() => _ = RenderingFactory.Create(new RenderingViewModel() { ImageBase64 = "eehu#ee"}));
    }
}