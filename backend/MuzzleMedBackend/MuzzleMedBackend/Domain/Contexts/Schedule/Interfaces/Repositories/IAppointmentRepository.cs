using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;

public interface IAppointmentRepository
{
    Task<AppointmentScheduleContext?> GetByIdAsync(Guid id);
    Task<AppointmentScheduleContext?> GetByDateAndTimeAsync(DateOnly date, TimeOnly time);
    Task<List<AppointmentScheduleContext>> GetByUserIdAsync(Guid userId);
    Task CreateAsync(AppointmentScheduleContext appointment);
    Task UpdateAsync(AppointmentScheduleContext appointment);
    
}