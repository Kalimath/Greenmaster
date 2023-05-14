using eu.mbdevelopment.greenmaster.Contracts.Base;
using eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;

namespace eu.mbdevelopment.greenmaster.Contracts.Botanical.Queries;

public class SpecieByScientificNameQuery : QueryBase<SpecieDto>
{
    public string ScientificName { get; set; }
    
    public SpecieByScientificNameQuery(string scientificName)
    {
        ScientificName = scientificName;
    }
}