using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IGetAppointmentsByUserUseCase
{
    Task<List<AppointmentScheduleContext>?> ExecuteAsync();
}