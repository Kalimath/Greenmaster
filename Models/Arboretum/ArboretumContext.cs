using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Greenmaster_ASP.Models.Static.Time.Durations;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Arboretum;

public class ArboretumContext : DbContext
{
    private readonly IExamplesService _examplesService;
    public DbSet<Specie> Species { get; set; } = null!;
    public DbSet<Rendering> Renderings { get; set; } = null!;
    
    /*public DbSet<Dimensions> PlantDimensions { get; set; } = null!;
    public DbSet<FlowerData> FlowerData { get; set; } = null!;
    public DbSet<FertiliserData> FertiliserData { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Plant> Plants { get; set; } = null!;
    public DbSet<PlantRequirements> PlantRequirements { get; set; } = null!;
    public DbSet<Domain> Domains { get; set; } = null!;
    public DbSet<Area> Areas { get; set; } = null!;
    public DbSet<Placeable> Placeables { get; set; } = null!;*/
    
    public IEnumerable<Specie> GetAllSpecies()
    {
        return Species;
    }

    public ArboretumContext(DbContextOptions<ArboretumContext> options, IExamplesService examplesService) : base(options)
    {
        _examplesService = examplesService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
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
        
        modelBuilder.Entity<Specie>().HasData(_examplesService.GetAllSpecies());
        modelBuilder.Entity<Rendering>().HasData(_examplesService.GetAllRenderings());
        
        /*modelBuilder.Entity<Domain>().HasMany(domain => domain.Placeables).WithMany(x => x.Domains);
        modelBuilder.Entity<Area>().HasOne(x => x.Domain).WithMany(x => x.Areas);
        modelBuilder.Entity<Area>().HasMany(x => x.EdgePoints).WithOne(x => x.Area);
        modelBuilder.Entity<Specie>().OwnsOne(x => x.MaxDimensions);
        modelBuilder.Entity<Specie>().HasOne(x => x.FlowerInfo);
        modelBuilder.Entity<Specie>().HasOne(x => x.Requirements);
        modelBuilder.Entity<Plant>().HasOne(x => x.Specie).WithMany(x => x.Plants).HasForeignKey(x => x.PlaceableId);
        modelBuilder.Entity<Plant>().HasOne(x => x.Position);
        modelBuilder.Entity<PlantRequirements>().OwnsOne(x => x.FertiliserInfo);*/
    }
}