using Microsoft.AspNetCore.Authorization;

namespace Greenmaster.ArboretumWebService.Permission;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}