using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;

namespace MuzzleMedBackend.Infrastructure.Contexts.Auth.Persistence;

public class UserAuthConfiguration : IEntityTypeConfiguration<UserAuthContext>
{
    public void Configure(EntityTypeBuilder<UserAuthContext> builder)
    {
        builder.ToTable("UsersAuth");
        
        builder.HasKey(u => u.Id);

        builder.Property(u => u.EmailAuthContext)
            .HasConversion(
                vo => vo.Address,
                dbString => new Email(dbString) 
            )
            .HasColumnName("Email")
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(u => u.PasswordHash)
            .HasColumnName("PasswordHash")
            .IsRequired();
    }
    
}