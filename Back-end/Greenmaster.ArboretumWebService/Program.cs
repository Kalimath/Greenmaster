using System.Reflection;
using FluentValidation.AspNetCore;
using Greenmaster.ArboretumWebService;
using Greenmaster.ArboretumWebService.Middleware;
using Greenmaster.Core.Extensions;
using Microsoft.IdentityModel.Logging;

const string allowedSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;


services.RegisterDependencies();
services.RegisterGreenmasterCore(builder.Configuration); //Register all Greenmaster.Core items (services, factories, EF and configuration)

services.RegisterAuthorization();
services.RegisterAuthentication();

//Identity
services.RegisterIdentity();
services.RegisterIdentityContext(builder.Configuration);

services.RegisterVersioning();
services.RegisterCors(allowedSpecificOrigins);
services.RegisterMailService(builder.Configuration);

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
services.RegisterDxos();
services.AddAutoMapper(Assembly.GetAssembly(typeof(DependencyInjection)));

services.AddHttpContextAccessor();
services.AddMvc().AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = false);
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedSpecificOrigins);

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.PrepareDatabase();