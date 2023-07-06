using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Contracts.Queries.Users;
using Greenmaster.Core.Models.Users;
using MediatR;

namespace Greenmaster.Core.Database.Handlers.Queries;

public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, IEnumerable<PermissionDto>>
{
    public async Task<IEnumerable<PermissionDto>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
    {
        var allmodules = Permission.AllModules;

        return allmodules.Select(module => new PermissionDto(module, Permission.GenerateAllPermissionsForModule(module))).ToList();
    }
}