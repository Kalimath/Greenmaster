using System.Text.Json.Serialization;
using eu.greenmaster.Models;
using eu.greenmaster.Models.Factories;
using eu.greenmaster.Repository;
using eu.greenmaster.Repository.Services.Example;
using eu.greenmaster.Repository.Services.Placeables;
using eu.greenmaster.Repository.Services.Rendering;
using eu.greenmaster.Repository.Services.Specie;
using eu.greenmaster.Repository.Services.Type;
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

services.AddSingleton<SpecieMapper>();
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