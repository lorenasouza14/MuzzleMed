namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Schedule.Entities;

public class PetScheduleConfiguration : IEntityTypeConfiguration<PetSchedule>
{
    public void Configure(EntityTypeBuilder<PetSchedule> builder)
    {
        builder.ToTable("Pets", "Schedule");
        
        builder.HasKey(p => p.PetId);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(80);
            
        builder.Property(p => p.Species)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);
    }
}