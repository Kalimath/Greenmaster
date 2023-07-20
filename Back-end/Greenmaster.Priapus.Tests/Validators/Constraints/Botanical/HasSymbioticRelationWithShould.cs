using Greenmaster.Core.Examples;
using Greenmaster.Core.Models;
using Greenmaster.Priapus.Validators.Constraints.Botanical;

namespace Greenmaster.Priapus.Tests.Validators.Constraints.Botanical;

public class HasSymbioticRelationWithShould
{
    //Inconclusive with XUnit
    [Fact]
    public void ReturnFalse_WhenSpecieGenusEqual()
    {
        
        var specie1 = SpecieExamples.Papaver;
        var specie2 = SpecieExamples.Papaver;
        
        var result = specie1.HasSymbioticRelationWith(specie2);
        
        Assert.False(result);
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieAIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => default(Specie)!.HasSymbioticRelationWith(SpecieExamples.Papaver));
    }
    
    [Fact]
    public void ReturnTrue_WhenSpecieGenusNotEqual_AndExistsInMutualisticGenera()
    {
        var specie = SpecieExamples.Papaver;
        var mutualSpecie = SpecieExamples.Aster;
        
        var expected = specie.MutualisticGenera.Contains(mutualSpecie.Genus);
        
        var result = specie.HasSymbioticRelationWith(mutualSpecie);
        
        Assert.Equal(expected, result);
    }
}