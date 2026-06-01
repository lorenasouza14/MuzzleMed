namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using Domain.Contexts.Profile.Entities;

public interface IUserRepository
{
    Task AddAsync(User user); //anotar o que é
}