namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases;

using Domain.Contexts.Schedule.Interfaces.Repositories;
using Domain.Contexts.Schedule.Interfaces.UseCases;

public class UpdateUserScheduleUseCase : IUpdateUserScheduleUseCase
{
    private readonly IUserScheduleRepository _repository;

    public UpdateUserScheduleUseCase(IUserScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid userId, string fullName, string phone)
    {
        var userSchedule = await _repository.GetByIdTrackingAsync(userId);

        if (userSchedule != null)
        {
            userSchedule.UpdateDetails(fullName, phone);
            // O SaveChanges será executado pelo UnitOfWork na classe UpdateUserUseCase do Profile
        }
    }
}