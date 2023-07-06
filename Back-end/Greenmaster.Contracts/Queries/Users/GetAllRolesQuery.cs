using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Contracts.Queries.Users;

public class GetAllRolesQuery : QueryBase<IEnumerable<RoleDto>>
{
}