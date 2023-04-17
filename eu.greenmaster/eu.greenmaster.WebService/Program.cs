using eu.greenmaster.EFCore;
using eu.greenmaster.EFCore.Services;
using eu.greenmaster.Models;
using eu.greenmaster.Models.Dxos.Specie;
using eu.greenmaster.Repository.Services.Example;
using eu.greenmaster.Repository.Services.Placeables;
using eu.greenmaster.Repository.Services.Rendering;
using eu.greenmaster.Repository.Services.Specie;
using eu.greenmaster.Repository.Services.Type;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddControllers();

//version
services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});

services.AddDbContext<ArboretumContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("localDb"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddMediatR(typeof(Program));

services.AddTransient<ISpecieService, SpecieService>();
services.AddTransient<IObjectTypeService<ObjectType>, ObjectTypeService>();
services.AddTransient<IObjectTypeService<PlantType>, PlantTypeService>();
services.AddTransient<IObjectTypeService<StructureType>, StructureTypeService>();
services.AddTransient<IRenderingService, RenderingService>();
services.AddTransient<IExamplesService, ExamplesService>();
services.AddTransient<IPlantService, PlantService>();
services.AddTransient<IStructureService, StructureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();