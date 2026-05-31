using Microsoft.EntityFrameworkCore;
// ADICIONADOS: Usings corretos do domínio e mapeamento de Veterinários
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Persistence;

namespace MuzzleMedBackend.Infrastructure.Persistence
{
    public class VeterinaryDbContext : DbContext
    {
        public VeterinaryDbContext(DbContextOptions<VeterinaryDbContext> options) : base(options)
        {
        }

       
        public DbSet<Veterinary> Veterinarians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.ApplyConfiguration(new VeterinarianConfiguration());
        }
    }
}