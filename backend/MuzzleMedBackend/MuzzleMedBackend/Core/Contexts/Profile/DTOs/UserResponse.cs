namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

public record UserResponse(
    Guid Id,
    string FullName,
    string Email,
    string Cpf,
    string Phone,
    DateOnly DateOfBirth
);