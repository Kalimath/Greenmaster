using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Models.Users;

public class Role : IdentityRole<Guid>
{
    public bool IsDeleted { get; set; }
    
    public Guid UserId { get; set; }
    
    public virtual User User { get; set; }

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