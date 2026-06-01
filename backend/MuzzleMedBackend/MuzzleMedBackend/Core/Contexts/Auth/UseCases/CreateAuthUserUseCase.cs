namespace MuzzleMedBackend.Core.Contexts.Auth.UseCases;

using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.UseCases;

public class CreateAuthUserUseCase : ICreateAuthUserUseCase
{
    private readonly IUserAuthContextRepository _repository;

    public CreateAuthUserUseCase(IUserAuthContextRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid userId, string email, string password)
    {
        var emailVo = new Email(email);
        var authUser = new UserAuthContext(userId, emailVo, password);
        
        _repository.SaveNewUserAuthContext(authUser);
        
        await Task.CompletedTask;
    }
}