using System.Reflection;
using FluentValidation;
using Greenmaster.Contracts.Base;
using Greenmaster.Core.Communication.Mail;
using Greenmaster.Core.Configuration;
using Greenmaster.Core.Database;
using Greenmaster.Core.Dxos.Image;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.Users;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Example;
using Greenmaster.Core.Services.GardenStyle;
using Greenmaster.Core.Services.MaterialType;
using Greenmaster.Core.Services.Placeables;
using Greenmaster.Core.Services.Rendering;
using Greenmaster.Core.Services.Specie;
using Greenmaster.Core.Services.Type;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Greenmaster.Core.Extensions;

public static class DependencyInjection
{
    private static void RegisterServices(this IServiceCollection services)
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

    private static void RegisterFactories(this IServiceCollection services)
    {
        services.AddSingleton<IModelFactory<Specie, SpecieViewModel>, SpecieFactory>();
        services.AddSingleton<IModelFactory<Rendering, RenderingViewModel>, RenderingFactory>();
        services.AddSingleton<IModelFactory<Placeable, PlaceableViewModel>, PlaceableFactory>();
        services.AddSingleton<IModelFactory<GardenStyle, GardenStyleViewModel>, GardenStyleFactory>();
    }

    public static void RegisterRenderingConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var configurationRoot = configuration.GetSection($"AppSettings:Rendering");

        services.Configure<RenderingConfig>(configurationRoot);
    }

    private static void RegisterApplicationContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ArboretumContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString($"localDb"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
    }

    public static void RegisterIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString($"localUserDb"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
    }

    public static void RegisterGreenmasterCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterServices();
        services.RegisterFactories();
        services.RegisterApplicationContext(configuration);
        
        services.AddAutoMapper(Assembly.GetAssembly(typeof(DependencyInjection)));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>()
            .ForEach(x =>
            {
                services.Add(ServiceDescriptor.Transient(x.InterfaceType, x.ValidatorType));
                services.Add(ServiceDescriptor.Transient(x.ValidatorType, x.ValidatorType));
            });
        
        services.AddTransient<IUsersDxos, UsersDxos>();
        services.AddTransient<IImageDxos, ImageDxos>();
        services.AddTransient<IRolesDxos, RolesDxos>();
    }
    
    public static void RegisterVersioning(this IServiceCollection services)
    {
        //version
        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
        });
    }
    
    //registerCrossOrigins
    public static void RegisterCors(this IServiceCollection services, string allowedSpecificOrigins)
    {
        //Cors
        services.AddCors(options =>
        {
            options.AddPolicy(name: allowedSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
        });
    }
    
    public static void RegisterIdentity(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddIdentity<User, Role>(config =>
        {
            config.Password.RequiredLength = 4;
            config.Password.RequireDigit = false;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireUppercase = false;
            //TODO: uncomment below lines to use email registration confirmation.
            //config.SignIn.RequireConfirmedEmail = true;
        }).AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
    }

    public static void RegisterMailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMailingService();
        MailService.SetKey(configuration["MailApiKey"]);
    }
}