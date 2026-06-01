namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases;

using Domain.Contexts.Schedule.Entities;
using Domain.Contexts.Schedule.Interfaces.UseCases;
using Domain.Contexts.Schedule.Interfaces.Repositories;

public class CreateUserScheduleUseCase : ICreateUserScheduleUseCase
{
    private readonly IUserScheduleRepository _repository;

    public CreateUserScheduleUseCase(IUserScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid userId, string fullName, string phone)
    {
        // Instancia a projeção de leitura do Schedule (validando os dados novamente pelo construtor)
        var userSchedule = new UserSchedule(userId, fullName, phone);

        // Deixa em espera no Entity Framework
        await _repository.AddAsync(userSchedule);
    }
}