using System.Drawing;
using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Static.Coloring;
using Xunit;
using Xunit.Sdk;

namespace Greenmaster_ASP.Tests.UnitTests.Extensions.ColorTests;

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
        var color = Color.Aqua;
        var expected = Color.FromArgb(255, Color.Red);
        
        if (color.IsWheelColor()) throw new FailException("color must not be a wheel color");
        Assert.Equal(expected, color.ComplementaryColor());
    }

    [Fact]
    public void ReturnExpectedOppositeColor_WhenColorIsNotAKnownColor()
    {
        var color = Color.FromArgb(44, 102, 155);
        var expected = Color.FromArgb(211,153,100);
        
        if (color.IsKnownColor) throw new FailException("color must not be a known color");
        Assert.Equal(expected, color.ComplementaryColor());
    }
}