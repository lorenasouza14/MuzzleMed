namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IUpdateUserScheduleUseCase
{
    Task ExecuteAsync(Guid userId, string fullName, string phone);
}