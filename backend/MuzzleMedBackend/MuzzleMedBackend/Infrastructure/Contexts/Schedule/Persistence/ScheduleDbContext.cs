using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

public class ScheduleDbContext : DbContext
{
    public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<AppointmentScheduleContext> AppointmentSchedules { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
    }
}