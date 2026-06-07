using MuzzleMedBackend.Domain.Contexts.Profile.Entities;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

public class GetHistoricByPetUseCase : IGetHistoricByPetUseCase
{
    private readonly IHistoricAppointmentRepository _historicRepository;

    public GetHistoricByPetUseCase(IHistoricAppointmentRepository historicRepository)
    {
        _historicRepository = historicRepository;
    }

    public async Task<List<HistoricAppointment>> ExecuteAsync(Guid petId)
    {
        return await _historicRepository.GetByPetIdAsync(petId);
    }
}