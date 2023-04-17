using eu.greenmaster.Contracts.Dtos.Species;

namespace eu.greenmaster.Contracts.Queries.Specie;

public class GetSpecieByScientificNameQuery : QueryBase<SpecieDto>
{
    public string ScientificName { get; set; }

    public GetSpecieByScientificNameQuery(string scientificName)
    {
        ScientificName = scientificName;
    } 
}