namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface ICreateUserScheduleUseCase
{
    Task ExecuteAsync(Guid userId, string fullName, string phone);
}