using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentByIdUseCase : IGetAppointmentByIdUseCase 
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IVetRepository _vetRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IPetScheduleRepository _petScheduleRepository;

    public GetAppointmentByIdUseCase(IAppointmentRepository appointmentRepository, IClinicRepository clinicRepository, IVetRepository vetRepository, IPetScheduleRepository petScheduleRepository)
    {
        _appointmentRepository = appointmentRepository;
        _clinicRepository = clinicRepository;
        _vetRepository = vetRepository;
        _petScheduleRepository = petScheduleRepository;
    }
    public async Task<AppointmentScheduleResponseDto?> ExecuteAsync(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        
        var appointment = await _appointmentRepository.GetByIdAsync(id);
        
        if (appointment == null) 
            return null;

        var clinic = await _clinicRepository.GetClinicById(appointment.ClinicId);
        var vet = await _vetRepository.GetVeterinaryById(appointment.VetId);
        var pet = await _petScheduleRepository.GetByIdAsync(appointment.PetId);

        return new AppointmentScheduleResponseDto
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
            PetName = pet.Name
        };
    }
    
}