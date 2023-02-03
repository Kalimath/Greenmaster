using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.StaticData;
using Greenmaster_ASP.Models.StaticData.Gradation;
using Greenmaster_ASP.Models.StaticData.Object.Organic;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Arboretum;

public class ArboretumContext : DbContext
{
    public DbSet<Specie> Species { get; set; } = null!;
    public DbSet<Dimensions> Dimensions { get; set; } = null!;
    public DbSet<FlowerData> FlowerData { get; set; } = null!;

    public ArboretumContext(DbContextOptions<ArboretumContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>().ToTable("Specie").HasOne<Dimensions>();
        modelBuilder.Entity<Specie>().HasOne<FlowerData>();
        modelBuilder.Entity<Dimensions>().ToTable("Dimensions");
        modelBuilder.Entity<FlowerData>().ToTable("FlowerData");
    }
}

public class Specie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SpecieId { get; set; }
    public string ScientificName { get; set; }
    public Requirement SunRequirement { get; set; }
    public Requirement WaterRequirement { get; set; }
    [ForeignKey(nameof(SpecieId))]
    public virtual FlowerData? FlowerInfo { get; set; }
    [ForeignKey(nameof(SpecieId))]
    public virtual Dimensions Dimensions { get; set; }
    public Lifecycle Lifecycle { get; set; }
}

public class FlowerData
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlowerDataId { get; set; }
    public Color color { get; set; } = Color.Green;
    //public Month[] FlowerPeriod { get; set; } = new Month[12];
    public bool IsFragrant { get; set; } = false;

    public int SpecieId { get; set; }
}

public class Dimensions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DimensionsId { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }

    public int SpecieId { get; set; }
}