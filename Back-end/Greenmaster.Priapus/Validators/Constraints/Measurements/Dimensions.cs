using Greenmaster.Core.Models;

namespace Greenmaster.Priapus.Validators.Constraints.Measurements;

public static class Dimensions
{
    public static double MinimumSpaceBetween(this Specie specie, Specie otherSpecie)
    {
        if (specie is null) throw new ArgumentNullException(nameof(specie));
        if (otherSpecie is null) throw new ArgumentNullException(nameof(otherSpecie));
        if(specie.MaxWidth <= 0) throw new ArgumentOutOfRangeException(nameof(specie.MaxWidth));
        if(otherSpecie.MaxWidth <= 0) throw new ArgumentOutOfRangeException(nameof(otherSpecie.MaxWidth));
        return specie.MaxWidth>otherSpecie.MaxWidth ? specie.MaxWidth : otherSpecie.MaxWidth;
    }
}