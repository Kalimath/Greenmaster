using eu.mbdevelopment.greenmaster.Contracts.Base;
using eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;

namespace eu.mbdevelopment.greenmaster.Contracts.Botanical.Queries;

public class SpecieByIdQuery : QueryBase<SpecieDto>
{
    public Guid Id { get; }
    
    public SpecieByIdQuery(Guid id)
    {
        Id = id;
    }
}