namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IDeletePetScheduleUseCase
{
    Task<bool> ExecuteAsync(Guid petScheduleId);
}