using eu.greenmaster.Contracts.Dtos.Species;

namespace eu.greenmaster.Contracts.Queries.Specie;

public class GetSpecieByIdQuery : QueryBase<SpecieDto>
{
    public int Id { get; set; }

    public GetSpecieByIdQuery(int id)
    {
        Id = id;
    }
}