using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IUpdateAppointmentSchedule
{
    public AppointmentScheduleContext? UpdateAppointmentSchedule(Guid id);
}