using Greenmaster_ASP.Models.Measurements;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Arboretum;

public class ArboretumContext : DbContext
{
    public DbSet<Specie> Species { get; set; } = null!;
    public DbSet<PlantDimensions> PlantDimensions { get; set; } = null!;
    public DbSet<SpecieDimensions> SpecieDimensions { get; set; } = null!;
    public DbSet<FlowerData> FlowerData { get; set; } = null!;
    public DbSet<FertiliserData> FertiliserData { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Plant> Plants { get; set; } = null!;
    public DbSet<PlantRequirements> PlantRequirements { get; set; } = null!;

    public ArboretumContext(DbContextOptions<ArboretumContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>().ToTable("Specie").HasOne<SpecieDimensions>();
        modelBuilder.Entity<Specie>().HasOne<FlowerData>();
        modelBuilder.Entity<Specie>().HasOne<PlantRequirements>();
        modelBuilder.Entity<Plant>().ToTable("Plant").HasOne<Specie>();
        modelBuilder.Entity<Plant>().HasOne<PlantDimensions>();
        modelBuilder.Entity<SpecieDimensions>().ToTable("SpecieDimensions");
        modelBuilder.Entity<PlantDimensions>().ToTable("PlantDimensions");
        modelBuilder.Entity<FlowerData>().ToTable("FlowerData");
        modelBuilder.Entity<PlantRequirements>().ToTable("PlantRequirements").HasOne<FertiliserData>();
        modelBuilder.Entity<FertiliserData>().ToTable("FertiliserData");
    }
}