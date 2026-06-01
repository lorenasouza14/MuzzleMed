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
        // 1. Instancia o Value Object de Email do contexto de Auth
        var emailVo = new Email(email);

        // 2. Cria a entidade com o ID vinculado ao Profile
        var authUser = new UserAuthContext(userId, emailVo, password);

        // 3. Adiciona ao rastreamento do banco (sem salvar ainda)
        _repository.SaveNewUserAuthContext(authUser);
        
        await Task.CompletedTask; // Apenas para manter a assinatura async caso a interface exija
    }
}