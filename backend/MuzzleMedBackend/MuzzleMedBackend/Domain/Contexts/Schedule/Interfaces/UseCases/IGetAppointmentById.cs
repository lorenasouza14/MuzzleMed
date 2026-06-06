using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IGetAppointmentById
{
    public AppointmentScheduleContext? Execute(Guid id);
}