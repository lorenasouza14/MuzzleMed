namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

using Domain.Contexts.Schedule.ValueObjects;

public interface ICreatePetScheduleUseCase
{
    Task ExecuteAsync(Guid petId, string name, string species, Guid userId); //por causa de erro
}