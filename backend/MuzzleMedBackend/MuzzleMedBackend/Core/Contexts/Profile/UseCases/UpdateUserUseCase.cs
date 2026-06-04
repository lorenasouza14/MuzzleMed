namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using Domain.Contexts.Profile.Interfaces;
using Domain.Contexts.Profile.ValueObjects;
using Core.Contexts.Profile.DTOs;
using Domain.Contexts.Schedule.Interfaces.UseCases;

public class UpdateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUpdateUserScheduleUseCase _scheduleUseCase;

    public UpdateUserUseCase(
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork,
        IUpdateUserScheduleUseCase scheduleUseCase)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _scheduleUseCase = scheduleUseCase;
    }

    public async Task ExecuteAsync(Guid userId, UpdateUserRequest request)
    {
        var user = await _userRepository.GetByIdTrackingAsync(userId);

        if (user == null)
            throw new ArgumentException("Usuário não encontrado.");

        var newPhone = new Phone(request.Phone);

        user.UpdateProfile(request.FullName, newPhone, request.DateOfBirth);

        await _scheduleUseCase.ExecuteAsync(user.Id, user.FullName, user.Phone.Number);

        await _unitOfWork.CommitAsync();
    }
}