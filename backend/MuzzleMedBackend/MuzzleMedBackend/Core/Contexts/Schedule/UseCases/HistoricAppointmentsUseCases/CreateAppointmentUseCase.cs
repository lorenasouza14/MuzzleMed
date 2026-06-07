using MuzzleMedBackend.Core.Contexts.Schedule.DTOs.HistoricAppointment;
using MuzzleMedBackend.Domain.Contexts.Profile.Entities;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

public class CreateHistoricUseCase : ICreateHistoricUseCase
{
    private readonly IHistoricAppointmentRepository _historicAppointmentRepository;
    
    
    public CreateHistoricUseCase(IHistoricAppointmentRepository historicAppointmentRepository)
    {
        _historicAppointmentRepository = historicAppointmentRepository;
    }

    public async Task<HistoricAppointment> ExecuteAsync(CreateHistoricDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var historic = new HistoricAppointment(
            dto.AppointmentId,
            dto.PetId,
            dto.Date,
            dto.Diagnostic,
            dto.Medication
        );

        await _historicAppointmentRepository.CreateAsync(historic);
        return historic;
    }
}