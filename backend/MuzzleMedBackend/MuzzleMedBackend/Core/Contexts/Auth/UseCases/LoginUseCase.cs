using MuzzleMedBackend.Core.Contexts.Auth.DTOs;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Auth.UseCases;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserAuthContextRepository _userAuthContextRepository;
    private readonly ITokenService _tokenService;
    
    public LoginUseCase(IUserAuthContextRepository userAuthContextRepository, ITokenService tokenService)
    {
        _userAuthContextRepository = userAuthContextRepository;
        _tokenService = tokenService;
    }

    public LoginResponseDto Execute(LoginRequestDto request)
    {
        var user = _userAuthContextRepository.GetByEmail(request.Email);

        if (user == null || !user.ValidatePassword(request.Password))
        {
            throw new Exception("Invalid email or password");
        }
        
        var token = _tokenService.GenerateToken(user);

        return new LoginResponseDto()
        {
            Token = token
        };
    }


}