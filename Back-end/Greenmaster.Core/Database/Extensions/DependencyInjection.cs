using Greenmaster.Core.Configuration;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Example;
using Greenmaster.Core.Services.GardenStyle;
using Greenmaster.Core.Services.MaterialType;
using Greenmaster.Core.Services.Placeables;
using Greenmaster.Core.Services.Rendering;
using Greenmaster.Core.Services.Specie;
using Greenmaster.Core.Services.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Greenmaster.Core.Database.Extensions;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecieService, SpecieService>();
        services.AddScoped<IObjectTypeService<ObjectType>, ObjectTypeService>();
        services.AddScoped<IObjectTypeService<PlantType>, PlantTypeService>();
        services.AddScoped<IObjectTypeService<StructureType>, StructureTypeService>();
        services.AddScoped<IRenderingService, RenderingService>();
        services.AddScoped<IExamplesService, ExamplesService>();
        services.AddScoped<IPlantService, PlantService>();
        services.AddScoped<IStructureService, StructureService>();
        services.AddScoped<IGardenStyleService, GardenStyleService>();
        services.AddScoped<IMaterialTypeService, MaterialTypeService>();
    }

    public static void RegisterFactories(this IServiceCollection services)
    {
        services.AddSingleton<IViewModelMapper<Specie, SpecieViewModel>, SpecieMapper>();
        services.AddSingleton<IViewModelMapper<Rendering, RenderingViewModel>, RenderingMapper>();
        services.AddSingleton<IViewModelMapper<Placeable, PlaceableViewModel>, PlaceableMapper>();
        services.AddSingleton<IViewModelMapper<GardenStyle, GardenStyleViewModel>, GardenStyleMapper>();
    }

    public static void RegisterRenderingConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var configurationRoot = configuration.GetSection($"AppSettings:Rendering");

        services.Configure<RenderingConfig>(configurationRoot);
    }

    public static void RegisterDataLink(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ArboretumContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString($"localDb"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
    }

    public static void RegisterGreenmasterCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterServices();
        services.RegisterFactories();
        services.RegisterDataLink(configuration);
        services.RegisterRenderingConfig(configuration);
    }
    
    public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
    {
        using var scopedServices = app.ApplicationServices.CreateScope();

        //Get dependency-injected items
        var serviceProvider = scopedServices.ServiceProvider;
        var applicationContext = serviceProvider.GetRequiredService<ArboretumContext>();
        var exampleService = serviceProvider.GetRequiredService<IExamplesService>();

        var dataInit = new DataInitializer(applicationContext, exampleService);
        await dataInit.SeedData();
        return app;
    }
}