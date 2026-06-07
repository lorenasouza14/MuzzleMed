namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.Interfaces;
using Core.Contexts.Profile.DTOs;
using Domain.Contexts.Schedule.Interfaces.UseCases;
using Domain.Contexts.Profile.ValueObjects;

public class CreatePetUseCase
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICreatePetScheduleUseCase _scheduleUseCase; 

    public CreatePetUseCase(
        IPetRepository petRepository, 
        IUnitOfWork unitOfWork,
        ICreatePetScheduleUseCase scheduleUseCase) 
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
        _scheduleUseCase = scheduleUseCase;
    }

    public async Task ExecuteAsync(CreatePetRequest request, Guid userId)
    {
        var pet = new Pet(
            request.Name, 
            request.Specie, 
            request.Breed, 
            request.DateOfBirth, 
            request.Gender,
            userId
        );
        
        await _petRepository.AddAsync(pet);

        await _scheduleUseCase.ExecuteAsync(pet.Id, pet.Name, pet.Specie.ToString(), pet.UserId);

        await _unitOfWork.CommitAsync();
    }
}