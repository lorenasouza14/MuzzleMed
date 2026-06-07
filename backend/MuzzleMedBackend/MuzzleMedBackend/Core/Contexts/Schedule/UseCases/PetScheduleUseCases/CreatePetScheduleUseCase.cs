namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.PetScheduleUseCases;

using Domain.Contexts.Schedule.Entities;
using Domain.Contexts.Schedule.Interfaces.UseCases;
using Domain.Contexts.Schedule.Interfaces.Repositories;
using Domain.Contexts.Schedule.ValueObjects;

public class CreatePetScheduleUseCase : ICreatePetScheduleUseCase
{
    private readonly IPetScheduleRepository _repository;

    public CreatePetScheduleUseCase(IPetScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid petId, string name, string species, Guid userId)
    {
        var localSpecieEnum = Enum.Parse<SpecieEnum>(species);

        var petSchedule = new PetSchedule(petId, name, localSpecieEnum, userId);

        await _repository.AddAsync(petSchedule);
    }
}