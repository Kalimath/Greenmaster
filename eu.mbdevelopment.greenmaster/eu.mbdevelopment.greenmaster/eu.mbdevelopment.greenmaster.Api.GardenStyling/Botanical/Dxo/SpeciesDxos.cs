using AutoMapper;
using eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;
using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;

namespace eu.mbdevelopment.greenmaster.Api.GardenStyling.Botanical.Dxo;

public class SpeciesDxos : ISpeciesDxos
{
    private readonly IMapper _mapper;

    public SpeciesDxos()
    {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Specie, SpecieDto>(); cfg.CreateMap<SpecieDto, Specie>();});
        _mapper = config.CreateMapper();
    }
    public SpecieDto MapSpecieDto(Specie specie)
    {
        return _mapper.Map<Specie, SpecieDto>(specie);
    }

    public IEnumerable<SpecieDto> MapSpaceDtos(IEnumerable<Specie> species)
    {
        return _mapper.Map<IEnumerable<SpecieDto>>(species);
    }
}