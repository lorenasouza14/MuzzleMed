using MuzzleMedBackend.Domain.Contexts.Profile.Entities;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.HistoricAppointmentsUseCases;

public class GetHistoricByIdUseCase : IGetHistoricByIdUseCase
{
    private readonly IHistoricAppointmentRepository _historicRepository;

    public GetHistoricByIdUseCase(IHistoricAppointmentRepository historicRepository)
    {
        _historicRepository = historicRepository;
    }
    public async Task<HistoricAppointment?> executeAsync(Guid id)
    {
        return await _historicRepository.GetByIdAsync(id);
    }
}