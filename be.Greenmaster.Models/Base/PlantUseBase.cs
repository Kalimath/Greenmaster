using be.Greenmaster.Models.Arboretum;

namespace be.Greenmaster.Models.Base;

public abstract class PlantUseBase<T> where T : Specie
{
    public T? Specie { get; private set; }

    protected PlantUseBase(T specie)
    {
        Specie = specie;
    }
}