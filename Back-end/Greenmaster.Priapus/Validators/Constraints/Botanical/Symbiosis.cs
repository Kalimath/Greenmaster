using Greenmaster.Core.Models;

namespace Greenmaster.Priapus.Validators.Constraints.Botanical;

public static class Symbiosis
{
    /// <summary>
    /// Returns true if SpecieA has a symbiotic relationship with SpecieB
    /// </summary>
    /// <exception cref="ArgumentNullException"> if specie a or B is null</exception>
    public static bool HasSymbioticRelationWith(this Specie specieA, Specie specieB)
    {
        const string errorMessage = "Could not determine symbiotic relation";
        if (specieA == null)
            throw new ArgumentNullException(nameof(specieA),errorMessage);
        if (specieB == null)
            throw new ArgumentNullException(nameof(specieB),errorMessage);
        
        return specieA.MutualisticGenera.Contains(specieB.Genus);
    }
}