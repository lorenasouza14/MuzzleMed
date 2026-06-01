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
        // 1. Instanciar os Value Objects
        var email = new Email(request.Email);
        var cpf = new Cpf(request.Cpf);
        var phone = new Phone(request.Phone);

        // 2. Criar a Entidade de Profile
        var user = new User(request.FullName, email, cpf, phone, request.DateOfBirth);

        // 3. Adicionar no Repositório de Profile
        await _userRepository.AddAsync(user);

        // 4. Enviar dados para o contexto de Schedule
        await _scheduleUseCase.ExecuteAsync(user.Id, user.FullName, user.Phone.Number);

        // 5. Enviar dados para o contexto de Auth
        await _authUseCase.ExecuteAsync(user.Id, request.Email ,request.Password);

        // 6. Efetivar todas as transações no banco
        await _unitOfWork.CommitAsync();
    }
}