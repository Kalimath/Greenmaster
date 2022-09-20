using be.Greenmaster.Models.Arboretum;
using be.Greenmaster.Models.StaticData;
using Xunit;

namespace be.Greenmaster.Models.UnitTests.Arboretum;

public class SpecieCtorShould
{
    [Fact]
    public void SetScientificNameCorrectlyWhenNotNullOrEmpty()
    {
        var validScientificName = "Strelitzia reginae";
        Specie validSpecie = new Specie(validScientificName);
        Assert.Equal(validScientificName, validSpecie.ScientificName);
    }

    [Fact]
    public void ThrowArgumentExceptionWhenScientificNameEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var badSpecie = new Specie("");
        });
    }
    
    [Fact]
    public void ThrowArgumentExceptionWhenScientificNameSizeIsInvalid()
    {
        var badSpecie = new Specie("tt");
    }
    
}