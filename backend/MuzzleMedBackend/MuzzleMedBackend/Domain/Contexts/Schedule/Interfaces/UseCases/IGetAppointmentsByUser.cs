using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IGetAppointmentsByUser
{
    List<AppointmentScheduleContext> ExecuteAsync(Guid userId);
}