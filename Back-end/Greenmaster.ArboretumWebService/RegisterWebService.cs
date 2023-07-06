using System.Reflection;
using Greenmaster.ArboretumWebService.Middleware;
using Greenmaster.ArboretumWebService.Permission;
using Greenmaster.Core.Database;
using Greenmaster.Core.Database.Base;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Graphic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace Greenmaster.ArboretumWebService;

public static class RegisterWebService
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IJwtMiddleware, JwtMiddleware>();
        services.AddTransient<IRepository<Specie>, Repository<Specie>>();
        services.AddTransient<IRepository<PlantType>, Repository<PlantType>>();
        services.AddTransient<IRepository<Image>, Repository<Image>>();
    }

    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.DescribeAllParametersInCamelCase();

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()

                    }
                });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
    public static void RegisterAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
    }
    public static void RegisterAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });
    }
}