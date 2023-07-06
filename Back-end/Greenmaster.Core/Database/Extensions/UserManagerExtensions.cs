using Greenmaster.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Database.Extensions;

public static class UserManagerExtensions
{
    public async static Task<User> GetFullUserByEmailAsync(this UserManager<User> userManager,string email)
    {
        return (await userManager.Users.Where(u => u.Email.Equals(email)).SingleOrDefaultAsync())!;
    }
    public async static Task<User> GetFullUserByIdAsync(this UserManager<User> userManager, Guid id)
    {
        return (await userManager.Users.Where(u => u.Id.Equals(id)).SingleOrDefaultAsync())!;
    }
}