namespace MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.UseCases;

public interface ICreateAuthUserUseCase
{
    Task ExecuteAsync(Guid userId, string email, string password);
}