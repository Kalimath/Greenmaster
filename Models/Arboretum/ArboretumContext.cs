using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
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
        return Species;
    }

    public ArboretumContext(DbContextOptions<ArboretumContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>().HasData(new List<Specie>()
        {
            new()
            {
                Id = 1,
                Genus = "Strelitzia",
                Species = "Reginae",
                Cultivar = "",
                CommonNames = "Bird of paradise,Paradijsvogelbloem",
                Description = "some text.",
                PlantType = PlantType.SmallShrub.Name,
                Cycle = Lifecycle.Perennial,
                Sunlight = Amount.Average,
                Water = Amount.Little,
                Climate = ClimateType.Tropical,
                MaxHeight = 2.5,
                MaxWidth = 0.75,
                BloomPeriod = new[]
                {
                    Month.May.ToString(), Month.June.ToString(), Month.July.ToString(), Month.August.ToString(),
                    Month.September.ToString(), Month.October.ToString()
                }
            },
            new()
            {
                Id = 2,
                Genus = "Papaver",
                Species = "Orientale",
                Cultivar = "Catherina",
                CommonNames = "Eastern poppy,Oosterse papaver",
                Description = "Beautiful straight plant",
                PlantType = PlantType.SmallShrub.Name,
                Cycle = Lifecycle.Annual,
                Sunlight = Amount.Average,
                Water = Amount.Little,
                Climate = ClimateType.Temperate,
                MaxHeight = 1,
                MaxWidth = 0.25, 
                BloomPeriod = new []{Month.May.ToString(), Month.June.ToString()}
            },
        });
        modelBuilder.Entity<Specie>()
            .Property(e => e.BloomPeriod)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
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