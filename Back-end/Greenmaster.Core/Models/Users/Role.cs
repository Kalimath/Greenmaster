using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Models.Users;

public class Role : IdentityRole<Guid>
{
    public bool IsDeleted { get; set; }

    public Role()
    {
    }

    public Role(string roleName) : base(roleName)
    {
        
    }
}

public enum Roles
{
    Admin,
    Limited
}