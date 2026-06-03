using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;
using MuzzleMedBackend.Infrastructure.Contexts.Auth.Persistence;
using MuzzleMedBackend.Infrastructure.Contexts.Profile.Persistence;
using MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Persistence;

namespace MuzzleMedBackend.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Schedule.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Pet> Pets { get; set; } = null!;
    public DbSet<HistoricAppointment> HistoricAppointments { get; set; } = null!;

    // Tabelas - Contexto Schedule
    public DbSet<UserSchedule> UserSchedules { get; set; } = null!;
    public DbSet<PetSchedule> PetSchedules { get; set; } = null!;
    public DbSet<Clinic> Clinics { get; set; } = null!;
    public DbSet<Veterinary> Veterinarians { get; set; } = null!;
    public DbSet<AppointmentScheduleContext> AppointmentSchedules { get; set; } = null!;
    

    //tabelas - conexto auth
    public DbSet<UserAuthContext> UsersAuth { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new HistoricAppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new UserScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new PetScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new UserAuthConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new VeterinarianConfiguration());
        
        //ignorando vos
        modelBuilder.Ignore<VetFullNameValueObject>();

    }
    
}