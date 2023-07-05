using AutoMapper;
using Greenmaster.Contracts.Dto;
using Greenmaster.Core.Models;

namespace Greenmaster.Core.Dxos.Species;

public interface ISpeciesDxo
{
    SpecieDto MapSpecieDto(Specie specie);
    IEnumerable<SpecieDto> MapSpecieDtos(IEnumerable<Specie> species);
    IEnumerable<Specie> MapDtosToSpecies(IEnumerable<SpecieDto> SpecieDtos);
}

public class SpeciesDxos : ISpeciesDxo
{
    private readonly IMapper _mapper;

    public SpeciesDxos()
    {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Specie, SpecieDto>(); cfg.CreateMap<SpecieDto, Specie>(); cfg.CreateMap<PlantType, PlantTypeDto>(); });
        _mapper = config.CreateMapper();
    }
    
    public SpecieDto MapSpecieDto(Specie specie)
    {
        return _mapper.Map<SpecieDto>(specie);
    }

    public IEnumerable<SpecieDto> MapSpecieDtos(IEnumerable<Specie> species)
    {
        return _mapper.Map<IEnumerable<SpecieDto>>(species);
    }

    public IEnumerable<Specie> MapDtosToSpecies(IEnumerable<SpecieDto> SpecieDtos)
    {
        return _mapper.Map<IEnumerable<Specie>>(SpecieDtos);
    }
}