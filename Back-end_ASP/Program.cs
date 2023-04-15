using System.Text.Json.Serialization;
using Greenmaster_ASP.Database.Arboretum;
using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Placeables;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.Services.Example;
using Greenmaster_ASP.Models.Services.Placeables;
using Greenmaster_ASP.Models.Services.Rendering;
using Greenmaster_ASP.Models.Services.Specie;
using Greenmaster_ASP.Models.Services.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
// services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

services.AddDbContext<ArboretumContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("localDb"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

services.AddSingleton<SpecieFactory>();
services.AddScoped<ISpecieService, SpecieService>();
services.AddScoped<IObjectTypeService<ObjectType>, ObjectTypeService>();
services.AddScoped<IObjectTypeService<PlantType>, PlantTypeService>();
services.AddScoped<IObjectTypeService<StructureType>, StructureTypeService>();
services.AddScoped<IRenderingService, RenderingService>();
services.AddScoped<IExamplesService, ExamplesService>();
services.AddScoped<IPlantService, PlantService>();
services.AddScoped<IStructureService, StructureService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Specie}/{action=Index}/{id?}");

app.Run();