using MuzzleMedBackend.Domain.Contexts.Profile.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

public interface IGetHistoricByIdUseCase
{
    Task<HistoricAppointment?> executeAsync(Guid id);
}