using MuzzleMedBackend.Core.Contexts.Auth.DTOs;

namespace MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.UseCases;

public interface ILoginUseCase
{
    public LoginResponseDto Execute(LoginRequestDto loginRequest);
}