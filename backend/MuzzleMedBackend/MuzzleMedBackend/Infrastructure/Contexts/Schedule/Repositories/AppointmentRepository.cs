using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;

namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;
    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public AppointmentScheduleContext? GetAppointmentById(Guid id)
    {
        var appointmentSchedule = _context.AppointmentSchedules.FirstOrDefault(x => x.Id == id);
        return appointmentSchedule;
    }

    public AppointmentScheduleContext? FindAppointmentByDateAndTime(DateOnly date, TimeOnly time)
    {
        var appointmentSchedule = _context.AppointmentSchedules.FirstOrDefault(x => x.Date == date && x.Time == time);
        return appointmentSchedule;
    }

    public List<AppointmentScheduleContext>? GetAppointmentSchedules(Guid userId)
    {
        var appointments  = _context.AppointmentSchedules.Where(x => x.UserId == userId).ToList();
        return appointments;
    }

    public AppointmentScheduleContext CreateAppointmentSchedule(AppointmentScheduleContext request)
    {
        _context.AppointmentSchedules.Add(request);
        _context.SaveChanges();
        return request;
    }

    public AppointmentScheduleContext UpdateAppointmentSchedule(Guid id, AppointmentScheduleContext request)
    {
        var appointment = GetAppointmentById(id);
        appointment.Status = request.Status;
        _context.AppointmentSchedules.Update(appointment);
        _context.SaveChanges();
        return appointment;
    }

    public AppointmentScheduleContext DeleteAppointmentSchedule(Guid id)
    {
        var appointment = GetAppointmentById(id);
        _context.AppointmentSchedules.Remove(appointment);
        _context.SaveChanges();
        return appointment;
    }
}