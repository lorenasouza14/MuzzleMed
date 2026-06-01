namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;

// Serve para dar o "Commit" (SaveChanges) de tudo de uma vez no banco
public interface IUnitOfWork
{
    Task CommitAsync();
}