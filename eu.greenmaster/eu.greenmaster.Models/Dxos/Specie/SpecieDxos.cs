using eu.greenmaster.Contracts.Dtos.Species;

namespace eu.greenmaster.Models.Dxos.Specie;

public class SpecieDxos : ISpecieDxos
{
    public Models.Specie MapSpecie(SpecieDto specieDto)
    {
        throw new NotImplementedException();
    }

    public SpecieDto mapSpecieDto(Models.Specie specie)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SpecieDto> MapSpecieDtos(List<Models.Specie> species)
    {
        throw new NotImplementedException();
    }
}