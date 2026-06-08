using MuzzleMedBackend.Domain.Contexts.Profile.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

public interface IGetHistoricByPetUseCase
{
    Task<List<HistoricAppointment>> ExecuteAsync(Guid petId);
}