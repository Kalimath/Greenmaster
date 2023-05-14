using eu.mbdevelopment.greenmaster.DataAccess.Shared.Extensions;
using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;
using Microsoft.EntityFrameworkCore;

namespace eu.mbdevelopment.greenmaster.DataAccess.Botanical;

public class BotanicalContext : DbContext
{
    public BotanicalContext(DbContextOptions<BotanicalContext> options)
        : base(options)
    {
    }
    
    public DbSet<Specie> Species { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>().ToTable("SPECIES");
        modelBuilder.Entity<Specie>().Property(specie => specie.CommonNames).HasConversion(name => string.Join(',', name ?? Array.Empty<string>()),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
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