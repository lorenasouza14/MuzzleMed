namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Profile.Entities;

public class HistoricAppointmentConfiguration : IEntityTypeConfiguration<HistoricAppointment>
{
    public void Configure(EntityTypeBuilder<HistoricAppointment> builder)
    {
        builder.ToTable("HistoricAppointments", "Profile");
        
        builder.HasKey(h => h.Id);
        
        builder.Property(h => h.AppointmentId)
            .IsRequired();
            
        builder.Property(h => h.Diagnostic)
            .IsRequired()
            .HasMaxLength(500);

        // O EF Core 8 suporta coleções primitivas nativamente (List<string>)
        builder.Property(h => h.Medication)
            .IsRequired();
    }
}