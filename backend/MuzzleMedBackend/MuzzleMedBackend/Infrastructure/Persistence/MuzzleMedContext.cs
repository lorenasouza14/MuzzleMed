using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Persistence; 

namespace MuzzleMedBackend.Infrastructure.Persistence;

public class MuzzleMedDbContext : DbContext
{
    public MuzzleMedDbContext(DbContextOptions<MuzzleMedDbContext> options) : base(options)
    {
    }

    public DbSet<Veterinary> Veterinarians { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuzzleMedDbContext).Assembly);
    }
}