using Greenmaster.Core.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core;

public class UserContext : IdentityDbContext<User, Role, Guid>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users").Property(e => e.PasswordHash).IsRequired(false);
        modelBuilder.Entity<User>().Property(e => e.PasswordSalt).IsRequired(false);
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<Role>().HasOne(r => r.User).WithMany(c => c.Roles)
            .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}