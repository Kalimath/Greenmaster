using eu.greenmaster.EFCore.Extensions;
using eu.greenmaster.Models;
using eu.greenmaster.Models.Measurements;
using eu.greenmaster.Models.Placeables;
using eu.greenmaster.Models.Static.Geographic;
using eu.greenmaster.Models.Static.Gradation;
using eu.greenmaster.Models.Static.Object.Organic;
using eu.greenmaster.Models.Static.Object.Rendering;
using eu.greenmaster.Models.Static.PlantProperties;
using eu.greenmaster.Models.Static.Time.Durations;
using eu.greenmaster.Repository.Services.Example;
using Microsoft.EntityFrameworkCore;

namespace eu.greenmaster.Repository;

public class ArboretumContext : DbContext
{
    private readonly IExamplesService _examplesService;
    public DbSet<Specie> Species { get; set; } = null!;
    public DbSet<Rendering> Renderings { get; set; } = null!;
    public DbSet<ObjectType> ObjectTypes { get; set; } = null!;
    public DbSet<PlantType> PlantTypes { get; set; } = null!;
    public DbSet<StructureType> StructureTypes { get; set; } = null!;
    public DbSet<Point> Points { get; set; } = null!;
    public DbSet<Dimensions> Dimensions { get; set; } = null!;
    public DbSet<Placeable> Placeables { get; set; } = null!;
    public DbSet<Plant> Plants { get; set; } = null!;
    public DbSet<Structure> Structures { get; set; } = null!;
    // public DbSet<Domain> Domains { get; set; } = null!;
    // public DbSet<Area> Areas { get; set; } = null!;
    
    public IEnumerable<Specie> GetAllSpecies()
    {
        return Species.Include(specie => specie.PlantType);
    }

    public Task<IEnumerable<Placeable>> GetAllPlaceables()
    {
        return Task.FromResult<IEnumerable<Placeable>>(Placeables
            .Include(placeable => placeable.Dimensions)
            .Include(placeable => placeable.Location)
            .Include(placeable => placeable.Type)
            .Include(placeable => placeable.Rendering));
    }
    public Task<IEnumerable<Structure>> GetAllStructures()
    {
        return Task.FromResult<IEnumerable<Structure>>(Structures
            .Include(plant => plant.Dimensions)
            .Include(plant => plant.Location)
            .Include(plant => plant.Type)
            .Include(placeable => placeable.Rendering));
    }
    public Task<IEnumerable<Plant>> GetAllPlants()
    {
        return Task.FromResult<IEnumerable<Plant>>(Plants
            .Include(plant => plant.Dimensions)
            .Include(plant => plant.Location)
            .Include(plant => plant.Type)
            .Include(placeable => placeable.Rendering)
            .Include(plant => plant.Specie).ToList());
    }

    public ArboretumContext(DbContextOptions<ArboretumContext> options, IExamplesService examplesService) : base(options)
    {
        _examplesService = examplesService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DefinePropertyConversions(modelBuilder);
        DefineSeedData(modelBuilder);
        
        modelBuilder.Entity<PlantType>().HasBaseType(typeof(ObjectType));
        modelBuilder.Entity<ObjectType>().HasDiscriminator<string>("objectType_type")
            .HasValue<PlantType>(nameof(PlantType))
            .HasValue<StructureType>(nameof(StructureType));
        modelBuilder.Entity<StructureType>().HasBaseType(typeof(ObjectType));
    }

    private static void DefinePropertyConversions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>()
            .Property(e => e.BloomPeriod)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Specie>()
            .Property(e => e.FlowerColors)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Cycle)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Lifecycle>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Shape)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Shape>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Sunlight)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Amount>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Water)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Amount>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Climate)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<ClimateType>(v));
        modelBuilder.Entity<Rendering>()
            .Property(e => e.Season)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Season>(v));
        modelBuilder.Entity<Rendering>()
            .Property(e => e.Type)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<RenderingObjectType>(v));
        modelBuilder.Entity<PlantType>()
            .Property(e => e.Canopy)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Permeability>(v));
    }

    private void DefineSeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Point>().HasData(_examplesService.GetAllPoints());
        modelBuilder.Entity<Dimensions>().HasData(_examplesService.GetAllDimensions());
        modelBuilder.Entity<Plant>().HasData(_examplesService.GetAllPlants());
        modelBuilder.Entity<Structure>().HasData(_examplesService.GetAllStructures());
        modelBuilder.Entity<PlantType>().HasData(_examplesService.GetAllPlantTypes());
        modelBuilder.Entity<StructureType>().HasData(_examplesService.GetAllStructureTypes());
        modelBuilder.Entity<Specie>().HasData(_examplesService.GetAllSpecies());
        modelBuilder.Entity<Rendering>().HasData(_examplesService.GetAllRenderings());
    }
    
    public override int SaveChanges()
    {
        this.AddAuditInfo();
        return base.SaveChanges();
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        this.AddAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

}