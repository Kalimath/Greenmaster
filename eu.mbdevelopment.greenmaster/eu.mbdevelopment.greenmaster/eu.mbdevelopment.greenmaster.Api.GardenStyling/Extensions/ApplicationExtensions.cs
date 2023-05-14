using eu.mbdevelopment.greenmaster.DataAccess.Botanical;
using eu.mbdevelopment.greenmaster.DataAccess.Botanical.Seeding;

namespace eu.mbdevelopment.greenmaster.Api.GardenStyling.Extensions;

public static class ApplicationExtensions
{
    public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
    {
        using var scopedServices = app.ApplicationServices.CreateScope();

        var serviceProvider = scopedServices.ServiceProvider;
        var botanicalContext = serviceProvider.GetRequiredService<BotanicalContext>();

        var dataInit = new BotanicalDataInitialiser(botanicalContext);
        await dataInit.SeedData();
        return app;
    }
}