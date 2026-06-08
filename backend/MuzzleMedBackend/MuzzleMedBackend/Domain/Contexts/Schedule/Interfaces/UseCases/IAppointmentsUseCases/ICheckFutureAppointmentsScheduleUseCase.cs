namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface ICheckFutureAppointmentsScheduleUseCase
{
    Task<bool> ExecuteAsync(Guid petId);
}