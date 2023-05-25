using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Services.Example;
using Greenmaster_ASP.Models.Services.GardenStyle;
using Greenmaster_ASP.Models.Services.MaterialType;
using Greenmaster_ASP.Models.Services.Placeables;
using Greenmaster_ASP.Models.Services.Rendering;
using Greenmaster_ASP.Models.Services.Specie;
using Greenmaster_ASP.Models.Services.Type;

namespace Greenmaster_ASP;

public static class DependecyInjection
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<SpecieFactory>();
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
}