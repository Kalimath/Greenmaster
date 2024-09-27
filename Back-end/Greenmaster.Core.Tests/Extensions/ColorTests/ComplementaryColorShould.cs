using Greenmaster.Core.Extensions;
using StaticData.Coloring;
using Xunit.Sdk;

namespace Greenmaster.Core.Tests.Extensions.ColorTests;

public class ComplementaryColorShould
{
    [Fact]
    public void ReturnGreen_WhenColorIsRed()
    {
        var color = Color.Red.ComplementaryColor();
        
        Assert.Equal(Color.Green, color);

    }

    [Fact]
    public void ReturnExpectedOppositeColor_WhenColorIsNotInColorWheel()
    {
        var color = Color.DarkSalmon;
        var expected = new Color(ColorName.Unspecified, new RgbColor(255-color.Rgb.Red, 255-color.Rgb.Green, 255-color.Rgb.Blue, 255));
        
        if (color.IsWheelColor()) throw new FailException("color must not be a wheel color");
        Assert.Equal(expected, color.ComplementaryColor());
    }
}