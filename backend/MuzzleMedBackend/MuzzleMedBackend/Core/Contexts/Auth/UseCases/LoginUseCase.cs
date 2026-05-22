using MuzzleMedBackend.Core.Contexts.Auth.DTOs;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;

namespace MuzzleMedBackend.Core.Contexts.Auth.UseCases;

public class LoginUseCase
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

        if (user == null || !user.ValidatePassword(request.Password)) //validate password foi definid na classe de user
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