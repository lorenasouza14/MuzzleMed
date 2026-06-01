namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Contexts.Profile.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "Profile"); // Define a tabela e o Schema
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(150);
            
        builder.Property(u => u.DateOfBirth)
            .IsRequired();

        // Mapeamento dos Value Objects (Owned Types)
        // O EF Core entenderá que esses dados pertencem à mesma tabela "Users"
        builder.OwnsOne(u => u.ProfileEmail, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("Email") // Nome da coluna no banco
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

        // Relacionamento 1:N (Um Usuário tem muitos Pets)
        builder.HasMany(u => u.Pets)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}