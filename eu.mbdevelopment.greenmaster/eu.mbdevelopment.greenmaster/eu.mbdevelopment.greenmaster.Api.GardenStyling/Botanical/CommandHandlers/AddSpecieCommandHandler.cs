using eu.mbdevelopment.greenmaster.Api.GardenStyling.Botanical.Dxo;
using eu.mbdevelopment.greenmaster.Contracts.Botanical.Commands;
using eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;
using eu.mbdevelopment.greenmaster.DataAccess.Base;
using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;
using MediatR;

namespace eu.mbdevelopment.greenmaster.Api.GardenStyling.Botanical.CommandHandlers;

public class AddSpecieCommandHandler : IRequestHandler<AddSpecieCommand, SpecieDto>
{
    public AddSpecieCommandHandler(IRepository<Specie> repository, ISpeciesDxos speciesDxos)
    {
    }

    public async Task<SpecieDto> Handle(AddSpecieCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}