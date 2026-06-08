using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;

namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;
    
    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<AppointmentScheduleContext?> GetByIdAsync(Guid id)
    {
        return await _context.AppointmentSchedules
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AppointmentScheduleContext?> GetByDateAndTimeAsync(DateOnly date, TimeOnly time)
    {
        return await _context.AppointmentSchedules
            .FirstOrDefaultAsync(x => x.Date == date && x.Time == time);
    }

    public async Task<List<AppointmentScheduleContext>> GetByUserIdAsync(Guid userId)
    {
        return await _context.AppointmentSchedules
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task CreateAsync(AppointmentScheduleContext appointment)
    {
        await _context.AppointmentSchedules.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AppointmentScheduleContext appointment)
    {
        _context.AppointmentSchedules.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<AppointmentScheduleContext?> GetAppointmentByClinicDateAndTime(Guid clinicId, Guid vetId,
        DateOnly date, TimeOnly time)
    {
        var appointment = await _context.AppointmentSchedules
            .FirstOrDefaultAsync(x => x.ClinicId == clinicId 
                                      && x.Date == date 
                                      && x.Time == time && x.VetId == vetId);
        
        return appointment;
        
    }
    
    public async Task<bool> HasFutureAppointmentsByPetIdAsync(Guid petId, DateOnly currentDate, TimeOnly currentTime)
    {
        return await _context.Set<AppointmentScheduleContext>()
            .AnyAsync(a => a.PetId == petId && 
                           a.Status == StatusEnum.Scheduled && 
                           (a.Date > currentDate || (a.Date == currentDate && a.Time > currentTime)));
    }

    public void UpdateWithOutSave(AppointmentScheduleContext appointment)
    {
        _context.Update(appointment);
    }
}