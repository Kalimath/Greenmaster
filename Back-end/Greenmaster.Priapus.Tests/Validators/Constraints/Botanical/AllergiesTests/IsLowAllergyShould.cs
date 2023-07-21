using Greenmaster.Core.Examples;
using Greenmaster.Core.Models;
using Greenmaster.Priapus.Validators.Constraints.Botanical;

namespace Greenmaster.Priapus.Tests.Validators.Constraints.Botanical.AllergiesTests;

public class IsLowAllergyShould
{
    [Fact]
    public void ReturnFalse_WhenSpecieProducesPollinatingFlowers()
    {
        var specie = SpecieExamples.Aster;
        
        var result = specie.IsLowAllergy();
        
        Assert.False(result);
    }
    
    [Fact]
    public void ReturnFalse_WhenSpecieGenusInHeavyPollinationGenera()
    {
        var specie = new Specie()
        {
            Genus = Allergies.HeavyPollinatingGenera.First()
        };
        
        var result = specie.IsLowAllergy();
        
        Assert.False(result);
    }

    [Fact]
    public void ReturnTrue_WhenSpecieDoesNotProducePollinatingFlowers()
    {
        var specie = SpecieExamples.Strelitzia;
        
        var result = specie.IsLowAllergy();
        
        Assert.True(result);
    }
}