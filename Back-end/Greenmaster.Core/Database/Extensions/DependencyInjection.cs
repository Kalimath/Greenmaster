using Greenmaster.Core.Configuration;
using Greenmaster.Core.Factories;
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
        services.AddSingleton<IModelFactory<Specie, SpecieViewModel>, SpecieFactory>();
        services.AddSingleton<IModelFactory<Rendering, RenderingViewModel>, RenderingFactory>();
        services.AddSingleton<IModelFactory<Placeable, PlaceableViewModel>, PlaceableFactory>();
        services.AddSingleton<IModelFactory<GardenStyle, GardenStyleViewModel>, GardenStyleFactory>();
    }

    public static void RegisterRenderingConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var configurationRoot = configuration.GetSection($"appsettings:Rendering");

        services.Configure<RenderingConfig>(configurationRoot.GetSection(key: "Rendering"));
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
}