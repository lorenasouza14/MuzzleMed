using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Infrastructure.Contexts.Auth.Persistence;

namespace MuzzleMedBackend.Infrastructure.Persistence;

public class AuthDbContext : DbContext
{public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public DbSet<UserAuthContext> UsersAuth { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserAuthConfiguration());
    }
}