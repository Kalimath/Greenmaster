using Greenmaster.Contracts.Dto;
using Greenmaster.Contracts.Queries;
using MediatR;

namespace Greenmaster.Core.Database.Handlers.Queries;

public class GetSpeciesQueryHandler : IRequestHandler<GetSpeciesQuery, IEnumerable<SpecieDto>>
{
    public async Task<IEnumerable<SpecieDto>> Handle(GetSpeciesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}