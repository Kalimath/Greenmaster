using Greenmaster_ASP.Models.Measurements;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Arboretum;

public class ArboretumContext : DbContext
{
    public DbSet<Specie> Species { get; set; } = null!;
    public DbSet<Dimensions> PlantDimensions { get; set; } = null!;
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
        /*modelBuilder.Entity<Dimensions>().ToTable("Dimensions");
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<FlowerData>().ToTable("FlowerData");
        modelBuilder.Entity<PlantRequirements>().ToTable("PlantRequirements");
        modelBuilder.Entity<FertiliserData>().ToTable("FertiliserData");
        modelBuilder.Entity<Specie>().ToTable("Specie");
        modelBuilder.Entity<Plant>().ToTable("Plant");*/
        modelBuilder.Entity<Specie>().OwnsOne(x=> x.MaxDimensions);
        modelBuilder.Entity<Specie>().HasOne(x=> x.FlowerInfo);
        modelBuilder.Entity<Specie>().HasOne(x=> x.Requirements);
        modelBuilder.Entity<Plant>().HasOne(x=> x.Specie).WithMany(x=> x.Plants).HasForeignKey(x => x.PlantId);
        modelBuilder.Entity<Plant>().OwnsOne(x=> x.DesiredDimensions);
        modelBuilder.Entity<Plant>().HasOne(x=> x.Position);
        modelBuilder.Entity<PlantRequirements>().OwnsOne(x => x.FertiliserInfo);
    }
}