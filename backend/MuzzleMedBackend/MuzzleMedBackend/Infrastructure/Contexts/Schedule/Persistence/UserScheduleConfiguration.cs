namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Schedule.Entities;

public class UserScheduleConfiguration : IEntityTypeConfiguration<UserSchedule>
{
    public void Configure(EntityTypeBuilder<UserSchedule> builder)
    {
        builder.ToTable("UsersSchedule"); // Schema diferente
        
        builder.HasKey(u => u.UserId); // PK mapeada diretamente para o Id vindo do Profile
        
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(150);
            
        builder.Property(u => u.Phone)
            .IsRequired()
            .HasMaxLength(15);
    }
}