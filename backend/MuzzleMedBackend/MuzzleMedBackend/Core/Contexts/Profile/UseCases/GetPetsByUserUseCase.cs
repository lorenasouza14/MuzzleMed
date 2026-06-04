namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using Domain.Contexts.Profile.Interfaces;
using Core.Contexts.Profile.DTOs;

public class GetPetsByUserUseCase
{
    private readonly IPetRepository _petRepository;

    public GetPetsByUserUseCase(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<IEnumerable<PetResponse>> ExecuteAsync(Guid userId)
    {
        var pets = await _petRepository.GetActivePetsByUserIdAsync(userId);

        return pets.Select(pet => new PetResponse(
            pet.Id,
            pet.Name,
            pet.Specie,
            pet.Breed,
            pet.DateOfBirth,
            pet.Gender
        ));
    }
}