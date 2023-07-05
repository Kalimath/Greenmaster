using System.Security.Claims;
using Greenmaster.Core.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
// ReSharper disable ComplexConditionExpression

namespace Greenmaster.ArboretumWebService.Permission;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public PermissionAuthorizationHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var user = (User)httpContext.Items["User"];

        if (user == null)
        {
            return;
        }
        var roleNames = await _userManager.GetRolesAsync(user);
        ICollection<Claim> allClaims = new List<Claim>();
        foreach (var roleName in roleNames)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                allClaims.Add(claim);
            }
        }

        var permission = allClaims.Any(x => x.Type == "Permission" &&
                                            x.Value == requirement.Permission &&
                                            x.Issuer == "LOCAL AUTHORITY");
        if (permission)
        {
            context.Succeed(requirement);
            return;
        }
    }
}