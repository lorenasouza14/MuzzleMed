using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Profile.Entities;
using System.Text.Json; // Necessário para salvar a List<string>

public class HistoricAppointmentConfiguration : IEntityTypeConfiguration<HistoricAppointment>
{
    public void Configure(EntityTypeBuilder<HistoricAppointment> builder)
    {
        builder.ToTable("HistoricAppointments");
        builder.HasKey(h => h.Id);
        
        builder.Property(h => h.AppointmentId).IsRequired();
        builder.Property(h => h.PetId).IsRequired();
        builder.Property(h => h.ClinicId).IsRequired();
        builder.Property(h => h.VetId).IsRequired();
            
        builder.Property(h => h.PetName)
            .IsRequired()
            .HasMaxLength(150);
            
        builder.Property(h => h.ClinicName)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(h => h.VetName)
            .HasConversion(
                vo => vo.ToString(), 
                str => new VetFullNameValueObject(str) 
            )
            .HasColumnName("VetName")
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(h => h.Date).IsRequired();

        builder.Property(h => h.SymptomDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(h => h.Diagnostic)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(h => h.Medication)
            .HasConversion(
                lista => JsonSerializer.Serialize(lista, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<List<string>>(json, (JsonSerializerOptions)null)
            )
            .IsRequired();
    }
}