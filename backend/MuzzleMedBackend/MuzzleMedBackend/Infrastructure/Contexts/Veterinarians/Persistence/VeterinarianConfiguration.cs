using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuzzleMedBackend.Domain.Contexts.Veterinarians;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Persistence
{
    public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinary>
    {
        public void Configure(EntityTypeBuilder<Veterinary> builder)
        {
            builder.ToTable("Veterinarians");

          
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).IsRequired();

            
            builder.Property(v => v.Name)
                .HasConversion(
                    vo => vo.FullName,                    
                    texto => new VetFullNameValueObject(texto))
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(v => v.ClinicId);
            builder.Property(v => v.ClinicId)
                .IsRequired();
        }
    }
}