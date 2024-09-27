
using Greenmaster.Core.Extensions;
using StaticData.Coloring;

namespace Greenmaster.Core.Tests.Extensions.ColorTests;

public class ToColorShould
{
    [Fact]
    public void ReturnCorrectColor()
    {
        Assert.Equal(Color.Green, Color.Green.Hex.ToColor());
        Assert.Equal(Color.ForestGreen, Color.ForestGreen.Hex.ToColor());
        Assert.Equal(Color.Yellow, Color.Yellow.Hex.ToColor());
    }

    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenNotFound()
    {
        const string invalidColorName = "InvalidColorName";

        Color Act() => invalidColorName.ToColor();
        
        Assert.Throws<ArgumentOutOfRangeException>(Act);
    }
}