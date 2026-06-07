using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;

public interface IAppointmentRepository
{
    public AppointmentScheduleContext? GetAppointmentById(Guid id);
    public AppointmentScheduleContext? FindAppointmentByDateAndTime(DateOnly date, TimeOnly time);
    public List<AppointmentScheduleContext>? GetAppointmentByUserIdSchedules(Guid userId);
    public AppointmentScheduleContext CreateAppointmentSchedule(AppointmentScheduleContext request);
    public AppointmentScheduleContext UpdateAppointmentSchedule(Guid id, AppointmentScheduleContext request);
    public AppointmentScheduleContext DeleteAppointmentSchedule(Guid dto);
    
}