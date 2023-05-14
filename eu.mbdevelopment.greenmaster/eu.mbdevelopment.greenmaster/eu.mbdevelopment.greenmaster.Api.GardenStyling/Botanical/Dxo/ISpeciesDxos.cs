using eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;
using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;

namespace eu.mbdevelopment.greenmaster.Api.GardenStyling.Botanical.Dxo;

public interface ISpeciesDxos
{
    SpecieDto MapSpecieDto(Specie specie);
    IEnumerable<SpecieDto> MapSpaceDtos(IEnumerable<Specie> species);
}