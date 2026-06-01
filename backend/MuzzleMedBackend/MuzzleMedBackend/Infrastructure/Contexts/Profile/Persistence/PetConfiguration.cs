namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Profile.Entities;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets", "Profile");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(80);
            
        builder.Property(p => p.Breed)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.Property(p => p.DateOfBirth)
            .IsRequired();
            
        builder.Property(p => p.IsActive)
            .IsRequired();

        builder.Property(p => p.Specie)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);
            
        builder.Property(p => p.Gender)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}