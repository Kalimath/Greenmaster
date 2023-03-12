using Greenmaster_ASP.Models.Measurements;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Arboretum;

public class ArboretumContext : DbContext
{
    public DbSet<Specie> Species { get; set; } = null!;
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
        return Species/*.Include(specie => specie.Requirements)
            .Include(specie => specie.MaxDimensions)
            .Include(specie => specie.FlowerInfo)*/;
    }

    public ArboretumContext(DbContextOptions<ArboretumContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>();
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