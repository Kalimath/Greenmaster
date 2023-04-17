using eu.greenmaster.Contracts.Dtos.Species;

namespace eu.greenmaster.Models.Dxos.Specie;

public interface ISpecieDxos
{
    Models.Specie MapSpecie(SpecieDto specieDto);

    SpecieDto mapSpecieDto(Models.Specie specie);
    IEnumerable<SpecieDto> MapSpecieDtos(List<Models.Specie> species);
}