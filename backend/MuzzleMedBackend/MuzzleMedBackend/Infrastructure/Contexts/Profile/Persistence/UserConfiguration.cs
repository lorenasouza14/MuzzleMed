namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Profile.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("UsersProfile"); 
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(150);
            
        builder.Property(u => u.DateOfBirth)
            .IsRequired();


        builder.OwnsOne(u => u.ProfileEmail, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("Email") 
                .IsRequired()
                .HasMaxLength(100);
        });

        builder.OwnsOne(u => u.Cpf, cpf =>
        {
            cpf.Property(c => c.Number)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11);
        });

        builder.OwnsOne(u => u.Phone, phone =>
        {
            phone.Property(p => p.Number)
                .HasColumnName("Phone")
                .IsRequired()
                .HasMaxLength(15);
        });

        // Relacionamento 1:N
        builder.HasMany(u => u.Pets)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}