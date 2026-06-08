using MuzzleMedBackend.Core.Contexts.Profile.DTOs;
using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class FinalizeAppointmentUseCase : IFinalizeAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly ICreateHistoricUseCase _historicAppointmentCreateUseCase;
    private readonly IVetRepository _vetRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IPetScheduleRepository _petScheduleRepository;

    public FinalizeAppointmentUseCase(IAppointmentRepository appointmentRepository, ICreateHistoricUseCase historicAppointmentCreateUseCase, IVetRepository vetRepository, IClinicRepository clinicRepository, IPetScheduleRepository petScheduleRepository)
    {
        _appointmentRepository = appointmentRepository;
        _historicAppointmentCreateUseCase = historicAppointmentCreateUseCase;
        _vetRepository = vetRepository;
        _clinicRepository = clinicRepository;
        _petScheduleRepository = petScheduleRepository;
    }

    public async Task<FinalizeAppointmentResponse> ExecuteAsync(Guid appointmentId, FinalizeAppointmentRequestDto dto)
    {
        ArgumentNullException.ThrowIfNull(appointmentId);
        ArgumentNullException.ThrowIfNull(dto);
        
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
        if (appointment == null)
        {
            throw new Exception("Agendamento nao encontrado");
        }
        
        appointment.Completed();
        await _appointmentRepository.UpdateAsync(appointment);
        
        var clinic = await _clinicRepository.GetClinicById(appointment.ClinicId);
        var vet = await _vetRepository.GetVeterinaryById(appointment.VetId);
        var pet = await _petScheduleRepository.GetByIdAsync(appointment.PetId);
        
        var historicAppointmentDto = new CreateHistoricAppointmentRequestDto
        {
            AppointmentId = appointmentId,
            Diagnostic = dto.Diagnostic,
            Medication = dto.Medications,
            Date = appointment.Date,
            VetId =  appointment.VetId,
            VetName = vet.Name,
            ClinicId = appointment.ClinicId,
            ClinicName = clinic.Name,
            PetId = appointment.PetId,
            PetName = pet.Name,
            SymptomDescription =  appointment.SymptomDescription,
            UserId = appointment.UserId,
        };
        
        await _historicAppointmentCreateUseCase.ExecuteAsync(historicAppointmentDto);
        
        
        var finalizeDto = new FinalizeAppointmentResponse()
        {
            Diagnostic = dto.Diagnostic,
            Medication = dto.Medications
        };
        
        return finalizeDto;
    }
}