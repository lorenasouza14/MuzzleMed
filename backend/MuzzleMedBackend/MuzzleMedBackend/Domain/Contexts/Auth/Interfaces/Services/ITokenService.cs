using MuzzleMedBackend.Domain.Contexts.Auth.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;

public interface ITokenService
{ 
    string GenerateToken(UserAuthContext user);
}