﻿using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.Time.Durations;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Models;

public class RenderingCtorShould
{
    [Fact]
    public void ThrowArgumentException_WhenPassedImageNull()
    {
        Assert.Throws<ArgumentException>(() => _ = new Rendering(1, null!, RenderingObjectType.Plant));
    }
    [Fact]
    public void ThrowArgumentException_WhenPassedImageEmpty()
    {
        Assert.Throws<ArgumentException>(() => _ = new Rendering(1, String.Empty, RenderingObjectType.Plant));
    }
    [Fact]
    public void ThrowArgumentException_WhenPassedImageWhitespace()
    {
        Assert.Throws<ArgumentException>(() => _ = new Rendering(1, "  ", RenderingObjectType.Plant));
    }
    [Fact]
    public void ThrowFormatException_WhenPassedImageNotBase64()
    {
        const string invalidBase64String = "jkijikj@e";
        Assert.Throws<FormatException>(() => _ = new Rendering(1, invalidBase64String, RenderingObjectType.Plant));
    }
    [Fact]
    public void SetImageToGiven_WhenPassed()
    {
        var result = new Rendering(1, Base64Examples.Image, RenderingObjectType.Plant);
        Assert.Equal(Base64Examples.Image, result.Image);
    }

    [Fact]
    public void SetSeasonToNotSet_WhenNotPassed()
    {
        var result = new Rendering(1, Base64Examples.Image, RenderingObjectType.Plant);
        Assert.Equal(Season.NotSet, result.Season);
    }
    
    [Fact]
    public void SetSeasonToGiven_WhenPassed()
    {
        var result = new Rendering(1, Base64Examples.Image, RenderingObjectType.Plant, Season.Spring);
        Assert.Equal(Season.Spring, result.Season);
    }
    
    [Fact]
    public void SetTypeToGiven_WhenPassed()
    {
        var result = new Rendering(1, Base64Examples.Image, RenderingObjectType.Plant);
        Assert.Equal(RenderingObjectType.Plant, result.Type);
    }
}