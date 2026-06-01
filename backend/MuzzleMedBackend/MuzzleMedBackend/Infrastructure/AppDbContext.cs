namespace MuzzleMedBackend.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Schedule.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Tabelas - Contexto Profile
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Pet> Pets { get; set; } = null!;
    public DbSet<HistoricAppointment> HistoricAppointments { get; set; } = null!;

    // Tabelas - Contexto Schedule
    public DbSet<UserSchedule> UserSchedules { get; set; } = null!;
    public DbSet<PetSchedule> PetSchedules { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Varre o projeto de Infrastructure procurando classes que herdam de IEntityTypeConfiguration e aplica automaticamente
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}