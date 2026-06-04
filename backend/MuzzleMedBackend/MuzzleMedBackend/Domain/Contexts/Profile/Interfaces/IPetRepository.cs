namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;

using Domain.Contexts.Profile.Entities;

public interface IPetRepository
{
    Task AddAsync(Pet pet);
}