namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;

// SaveChages em tudo de uma vez
public interface IUnitOfWork
{
    Task CommitAsync();
}