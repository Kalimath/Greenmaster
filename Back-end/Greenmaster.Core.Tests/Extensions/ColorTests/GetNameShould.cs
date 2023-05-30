using System.Drawing;
using Greenmaster.Core.Models.Extensions;

namespace Greenmaster.Core.Tests.Extensions.ColorTests;

public class GetNameShould
{
    [Fact]
    public void ReturnCorrectName()
    {
        Assert.Equal("Green", Color.Green.GetName());
        Assert.Equal("SlateBlue", Color.SlateBlue.GetName());
        Assert.Equal("Yellow", Color.Yellow.GetName());
        Assert.Equal("Red", Color.FromArgb(255,0,0).GetName());
    }

    [Fact]
    public void ReturnEmptyName_WhenNotFound()
    {
        Assert.Equal(string.Empty, Color.FromArgb(240,10,80).GetName());
    }
}