using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentScheduleContext>
{
    public void Configure(EntityTypeBuilder<AppointmentScheduleContext> builder)
    {
        builder.ToTable("AppointmentSchedules");
        
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id);
        
        builder.HasIndex(a => a.UserId);
        builder.Property(a => a.UserId).IsRequired();
        
        builder.HasIndex(a => a.PetId);
        builder.Property(a => a.PetId).IsRequired();
        
        builder.HasIndex(a => a.VetId);
        builder.Property(a => a.VetId).IsRequired();
        
        builder.HasIndex(a => a.ClinicId);
        builder.Property(a => a.ClinicId).IsRequired();
        
        builder.Property(a => a.Date).IsRequired();
        
        builder.Property(a => a.Time).IsRequired();
        
        builder.Property(a => a.Status).IsRequired();
        
        builder.Property(a => a.SymptomDescription).IsRequired().HasMaxLength(150);
        
    }
}