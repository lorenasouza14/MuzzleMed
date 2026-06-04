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

    public async Task ExecuteAsync(Guid petId, string name, string species)
    {
        // Converte a string vinda do Profile para o Enum local do Schedule
        var localSpecieEnum = Enum.Parse<SpecieEnum>(species);

        // Instancia a projeção de leitura do Schedule usando o Enum local
        var petSchedule = new PetSchedule(petId, name, localSpecieEnum);

        await _repository.AddAsync(petSchedule);
    }
}