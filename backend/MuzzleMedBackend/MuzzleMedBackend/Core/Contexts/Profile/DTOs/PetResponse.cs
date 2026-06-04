namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

using Domain.Contexts.Profile.ValueObjects;

public record PetResponse(
    Guid Id,
    string Name,
    SpecieEnum Specie,
    string Breed,
    DateOnly DateOfBirth,
    GenderEnum Gender
);