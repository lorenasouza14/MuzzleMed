namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.ValueObjects;
using Domain.Contexts.Profile.Interfaces;
using Core.Contexts.Profile.DTOs;
using Domain.Contexts.Auth.Interfaces.UseCases;
using Domain.Contexts.Schedule.Interfaces.UseCases;

public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICreateAuthUserUseCase _authUseCase; 
    private readonly ICreateUserScheduleUseCase _scheduleUseCase;

    public CreateUserUseCase(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        ICreateAuthUserUseCase authUseCase,
        ICreateUserScheduleUseCase scheduleUseCase)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _authUseCase = authUseCase;
        _scheduleUseCase = scheduleUseCase;
    }

    public async Task ExecuteAsync(CreateUserRequest request)
    {
        var email = new Email(request.Email);
        var cpf = new Cpf(request.Cpf);
        var phone = new Phone(request.Phone);
        
        if (await _userRepository.ExistsByCpfAsync(cpf.Number))
        {
            throw new ArgumentException("Este CPF já está cadastrado no sistema.");
        }

        var user = new User(request.FullName, email, cpf, phone, request.DateOfBirth);

        await _userRepository.AddAsync(user);
        await _scheduleUseCase.ExecuteAsync(user.Id, user.FullName, user.Phone.Number);
        await _authUseCase.ExecuteAsync(user.Id, request.Email ,request.Password);

        await _unitOfWork.CommitAsync();
    }
}