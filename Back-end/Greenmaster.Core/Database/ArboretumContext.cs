using Greenmaster.Core.Database.Interfaces;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Measurements;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Services.Example;
using Microsoft.EntityFrameworkCore;

// ReSharper disable TooManyDeclarations

namespace Greenmaster.Core.Database;

public class ArboretumContext : DbContext, IApplicationDbContext
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
    public DbSet<GardenStyle> GardenStyles { get; set; } = null!;
    public DbSet<MaterialType> MaterialTypes { get; set; } = null!;
    
    
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

    public Task<IEnumerable<GardenStyle>> GetAllGardenStyles()
    {
        return Task.FromResult<IEnumerable<GardenStyle>>(GardenStyles.Include(style => style.Materials).ToList());
    }

    public ArboretumContext(DbContextOptions<ArboretumContext> options, IExamplesService examplesService) : base(options)
    {
        _examplesService = examplesService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DefinePropertyConversions(modelBuilder);
        SeedData(modelBuilder);

        modelBuilder.Entity<ObjectType>().HasDiscriminator<string>("objectType_type")
            .HasValue<PlantType>(nameof(PlantType))
            .HasValue<StructureType>(nameof(StructureType));
        modelBuilder.Entity<PlantType>().HasBaseType(typeof(ObjectType));
        modelBuilder.Entity<StructureType>().HasBaseType(typeof(ObjectType));
        
        modelBuilder.Entity<Placeable>().HasDiscriminator<string>("placeable_filler")
            .HasValue<Plant>(nameof(Plant))
            .HasValue<Structure>(nameof(Structure));
        modelBuilder.Entity<Plant>().HasBaseType(typeof(Placeable));
        modelBuilder.Entity<Plant>().HasOne<Specie>(t => t.Specie)
            .WithMany(p => p.Plants).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Structure>().HasBaseType(typeof(Placeable));
        
        modelBuilder.Entity<GardenStyle>()
            .HasMany<MaterialType>(s => s.Materials)
            .WithMany(c => c.GardenStyles);
        
        modelBuilder.Entity<MaterialType>().HasMany(m => m.GardenStyles)
           .WithMany(m => m.Materials);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Point>().HasData(_examplesService.GetAllPoints());
        // modelBuilder.Entity<Dimensions>().HasData(_examplesService.GetAllDimensions());
        // modelBuilder.Entity<Plant>().HasData(_examplesService.GetAllPlants());
        //modelBuilder.Entity<Structure>().HasData(_examplesService.GetAllStructures());
        modelBuilder.Entity<PlantType>().HasData(_examplesService.GetAllPlantTypes());
        modelBuilder.Entity<StructureType>().HasData(_examplesService.GetAllStructureTypes());
        // modelBuilder.Entity<Specie>().HasData(_examplesService.GetAllSpecies());
        // modelBuilder.Entity<Rendering>().HasData(_examplesService.GetAllRenderings());
        // modelBuilder.Entity<GardenStyle>().HasData(_examplesService.GetAllGardenStyles());
        modelBuilder.Entity<MaterialType>().HasData(_examplesService.GetAllMaterialTypes());
    }

    private static void DefinePropertyConversions(ModelBuilder modelBuilder)
    {
        PropertyConversions.SpecieConverters(modelBuilder);
        PropertyConversions.GardenStyleConverters(modelBuilder);
        PropertyConversions.RenderingConverters(modelBuilder);
        PropertyConversions.PlantTypeConverters(modelBuilder);
    }
}