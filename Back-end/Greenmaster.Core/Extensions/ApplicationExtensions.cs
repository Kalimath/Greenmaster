using Greenmaster.Core.Database;
using Greenmaster.Core.Models.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Greenmaster.Core.Extensions;

public static class ApplicationsExtensions
{
    public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
    {
        using var scopedServices = app.ApplicationServices.CreateScope();

        var serviceProvider = scopedServices.ServiceProvider;
        var userContext = serviceProvider.GetRequiredService<UserContext>();
        var applicationContext = serviceProvider.GetRequiredService<ArboretumContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        var dataInit = new DataInitializer(userContext, applicationContext, userManager, roleManager);
        await dataInit.SeedData();
        return app;
    }
}