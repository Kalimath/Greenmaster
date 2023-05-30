using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Measurements;
using Greenmaster.Core.Models.Placeables;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Database.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Specie> Species { get; set; }
    public DbSet<Rendering> Renderings { get; set; }
    public DbSet<ObjectType> ObjectTypes { get; set; }
    public DbSet<PlantType> PlantTypes { get; set; }
    public DbSet<StructureType> StructureTypes { get; set; }
    public DbSet<Point> Points { get; set; }
    public DbSet<Dimensions> Dimensions { get; set; }
    public DbSet<Placeable> Placeables { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Structure> Structures { get; set; }
    public DbSet<GardenStyle> GardenStyles { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
}