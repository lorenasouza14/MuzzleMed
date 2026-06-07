using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases;

using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public class CheckFutureAppointmentsUseCase : ICheckFutureAppointmentsScheduleUseCase
{
    private readonly IAppointmentRepository _repository;

    public CheckFutureAppointmentsUseCase(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(Guid petId)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var now = TimeOnly.FromDateTime(DateTime.UtcNow);

        return await _repository.HasFutureAppointmentsByPetIdAsync(petId, today, now);
    }
}