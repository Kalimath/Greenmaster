﻿using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Core.Database.Queries.Users;

public class GetAllPermissionsQuery: QueryBase<IEnumerable<PermissionDto>>
{
}