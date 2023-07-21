using Greenmaster.Core.Models;

namespace Greenmaster.Priapus.Validators.Constraints.Botanical;

public static class Allergies
{
    public static bool IsLowAllergy(this Specie specie)
    {
        return !specie.PollinatingFlowers;
    }
}