namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

public record CreateUserRequest(
    string FullName,
    string Email,
    string Cpf,
    string Phone,
    DateTime DateOfBirth,
    string Password 
);