namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

public record UpdateUserRequest(
    string FullName,
    string Phone,
    DateOnly DateOfBirth
);