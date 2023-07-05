using Greenmaster.Contracts.Dto;
using MediatR;

namespace Greenmaster.Core.Database.Queries;

public record GetSpeciesQuery() : IRequest<IEnumerable<SpecieDto>>, IRequest<SpecieDto>;