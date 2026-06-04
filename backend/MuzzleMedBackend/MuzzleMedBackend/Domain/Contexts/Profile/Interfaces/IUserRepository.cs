namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using Domain.Contexts.Profile.Entities;

public interface IUserRepository
{
    Task AddAsync(User user); 
    Task<bool> ExistsByCpfAsync(string cpf);
    Task<User?> GetByIdAsync(Guid id);
}