namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using Domain.Contexts.Profile.Interfaces;
using Core.Contexts.Profile.DTOs;

public class GetUserProfileUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserProfileUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> ExecuteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new ArgumentException("Usuário não encontrado.");
        }

        return new UserResponse(
            user.Id,
            user.FullName,
            user.ProfileEmail.Address, 
            user.Cpf.Number,
            user.Phone.Number,
            user.DateOfBirth
        );
    }
}