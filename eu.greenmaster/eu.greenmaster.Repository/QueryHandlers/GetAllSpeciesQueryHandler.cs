using eu.greenmaster.Contracts.Dtos.Species;
using eu.greenmaster.Contracts.Queries.Specie;
using eu.greenmaster.EFCore;
using eu.greenmaster.EFCore.Services;
using eu.greenmaster.Models.Dxos.Specie;
using MediatR;
using Stoelendans.Repositories;

namespace eu.greenmaster.Repository.QueryHandlers;

public class GetAllSpeciesQueryHandler : IRequestHandler<GetAllSpeciesQuery, IEnumerable<SpecieDto>>
{
    private readonly ISpecieService _specieService;
    private readonly ISpecieDxos _specieDxos;


    public GetAllSpeciesQueryHandler(ISpecieService specieService, ISpecieDxos specieDxos)
    {
        _specieService = specieService;
        _specieDxos = specieDxos;
    }
    
    public async Task<IEnumerable<SpecieDto>> Handle(GetAllSpeciesQuery request, CancellationToken cancellationToken)
    {
        var species = await _specieService.GetAll();
        if (species == null)
        {
            throw new NullReferenceException();
        }
        return _specieDxos.MapSpecieDtos(species);
    }
}