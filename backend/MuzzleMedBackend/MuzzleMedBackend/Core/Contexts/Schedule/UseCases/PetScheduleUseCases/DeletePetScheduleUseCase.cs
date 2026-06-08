using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.PetScheduleUseCases;

public class DeletePetScheduleUseCase : IDeletePetScheduleUseCase
{
    private readonly IPetScheduleRepository _petScheduleRepository;

    public DeletePetScheduleUseCase(IPetScheduleRepository petScheduleRepository)
    {
        _petScheduleRepository = petScheduleRepository;
    }

    public async Task<bool> ExecuteAsync(Guid petScheduleId)
    {
        ArgumentNullException.ThrowIfNull(petScheduleId, nameof(petScheduleId));
        
        var pet = await _petScheduleRepository.GetByIdAsync(petScheduleId);
        if (pet == null)
        {
            throw new ArgumentNullException("Pet em Schedule nao encontrado");
        }
        
        pet.Deactivate();
        _petScheduleRepository.UpdateWithOutSave(pet);
        return true;
    }
}