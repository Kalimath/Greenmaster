using eu.mbdevelopment.greenmaster.DataAccess.Base;
using eu.mbdevelopment.greenmaster.DataAccess.Botanical;
using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;
using Microsoft.EntityFrameworkCore;

namespace eu.mbdevelopment.greenmaster.Api.GardenStyling;

public static class RegisterGardenStyling
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Specie>, Repository<Specie>>();
        
    }
}