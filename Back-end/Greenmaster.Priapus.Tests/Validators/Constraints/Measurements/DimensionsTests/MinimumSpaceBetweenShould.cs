using Greenmaster.Core.Examples;
using Greenmaster.Core.Models;
using Greenmaster.Priapus.Validators.Constraints.Measurements;

namespace Greenmaster.Priapus.Tests.Validators.Constraints.Measurements.DimensionsTests;

public class MinimumSpaceBetweenShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieIsNull()
    {
        double Act() => ((Specie)null!).MinimumSpaceBetween(SpecieExamples.Papaver);
        
        Assert.Throws<ArgumentNullException>(() => Act());
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenOtherSpecieIsNull()
    {
        double Act() => SpecieExamples.Papaver.MinimumSpaceBetween(null!);
        
        Assert.Throws<ArgumentNullException>(() => Act());
    }
    
    //test to check if MinimumSpaceBetween throws argumentException when dimensions of specie is null
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenMaxWidthOfSpecieIsInvalid()
    {
        var specieWithInvalidMaxWidth = new Specie()
        {
            MaxWidth = -21
        };
        
        double Act() => specieWithInvalidMaxWidth.MinimumSpaceBetween(SpecieExamples.Papaver);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => Act());
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenMaxWidthOfOtherSpecieIsInvalid()
    {
        var otherSpecieWithInvalidMaxWidth = new Specie()
        {
            MaxWidth = -21
        };
        
        double Act() => SpecieExamples.Papaver.MinimumSpaceBetween(otherSpecieWithInvalidMaxWidth);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => Act());
    }
    
    //test to check if MinimumSpaceBetween returns highest Specie.MaxHeight
    [Fact]
    public void ReturnHighestMaxHeightOfBothSpecies()
    {
        var specie = SpecieExamples.Papaver;
        var otherSpecie = SpecieExamples.Aster;
        var highestWidth = specie.MaxWidth>otherSpecie.MaxWidth ? specie.MaxWidth : otherSpecie.MaxWidth;
        
        var result = specie.MinimumSpaceBetween(otherSpecie);
        
        Assert.Equal(highestWidth, result);
    }
}