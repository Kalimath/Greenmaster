using Greenmaster.Contracts.Dto;
using MediatR;

namespace Greenmaster.Contracts.Queries;

public record GetSpeciesQuery() : IRequest<IEnumerable<SpecieDto>>, IRequest<SpecieDto>;