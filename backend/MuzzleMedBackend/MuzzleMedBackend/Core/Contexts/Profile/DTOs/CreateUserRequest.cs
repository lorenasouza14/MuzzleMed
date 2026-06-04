namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

public record CreateUserRequest(
    string FullName,
    string Email,
    string Cpf,
    string Phone,
    DateOnly DateOfBirth,
    string Password 
);