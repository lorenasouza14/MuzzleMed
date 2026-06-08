using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class BuildAppointmentResponseUseCase : IBuildAppointmentResponseUseCase
{
    private readonly IVetRepository _vetRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IPetScheduleRepository _petScheduleRepository;

    public BuildAppointmentResponseUseCase(IVetRepository vetRepository, IClinicRepository clinicRepository, IPetScheduleRepository petScheduleRepository)
    {
        _vetRepository = vetRepository;
        _clinicRepository = clinicRepository;
        _petScheduleRepository = petScheduleRepository;
    }

    public async Task<AppointmentResponseDto> ExecuteAsync(AppointmentScheduleContext appointment)
    {
        var clinic = await _clinicRepository.GetClinicById(appointment.ClinicId);
        var vet = await _vetRepository.GetVeterinaryById(appointment.VetId);
        var pet = await _petScheduleRepository.GetByIdAsync(appointment.PetId);
        
        return new AppointmentResponseDto
        {
            Id = appointment.Id,
            Date = appointment.Date,
            Time = appointment.Time,
            Status = appointment.Status.ToString(),
            ClinicId = appointment.ClinicId,
            ClinicName = clinic.Name,
            VetId = appointment.VetId,
            VetName = vet.Name,
            PetId = appointment.PetId,
            PetName = pet.Name,
            SymptomDescription = appointment.SymptomDescription
        };
    }
}