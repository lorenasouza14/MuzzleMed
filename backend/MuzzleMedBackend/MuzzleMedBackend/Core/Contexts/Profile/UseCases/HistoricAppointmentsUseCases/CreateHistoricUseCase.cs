using MuzzleMedBackend.Core.Contexts.Profile.DTOs;
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

    public async Task<HistoricAppointment> ExecuteAsync(CreateHistoricAppointmentRequestDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        
        var historic = new HistoricAppointment(dto.AppointmentId,
            dto.PetId,
            dto.Date,
            dto.Diagnostic,
            dto.Medication,
            dto.ClinicId,
            dto.VetId,
            dto.SymptomDescription,
            dto.PetName,
            dto.ClinicName,
            dto.VetName);

        await _historicAppointmentRepository.CreateAsync(historic);
        return historic;
    }
    
}