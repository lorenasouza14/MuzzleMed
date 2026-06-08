using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class CreateAppointmentUseCase : ICreateAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IGetUserIdService _getUserIdService;
    private readonly IPetScheduleRepository _petScheduleRepository;
    private readonly IVetRepository _vetRepository;

    public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository, IGetUserIdService getUserIdService, IPetScheduleRepository petScheduleRepository, IUserScheduleRepository userScheduleRepository, IVetRepository vetRepository)
    {
        _appointmentRepository = appointmentRepository;
        _getUserIdService = getUserIdService;
        _petScheduleRepository = petScheduleRepository;
        _vetRepository = vetRepository;
    }
    public async Task<AppointmentScheduleContext> ExecuteAsync(CreateAppointmentRequestDto requestDto)
    {
        ArgumentNullException.ThrowIfNull(requestDto);
        
        var appointmentDateTime = requestDto.Date.ToDateTime(requestDto.Time);
        if (appointmentDateTime < DateTime.Now)
        {
            throw new InvalidOperationException("Data de agendamento nao pode ser menor que a data atual");
        }
        
        var userId =  _getUserIdService.GetUserId();
        
        
        var pet = await _petScheduleRepository.GetByIdAsync(requestDto.PetId);
        
        if (pet == null || pet.IsActive == false)
        {
            throw new ArgumentException("Pet não existe");
        }
        if (pet.UserId != userId)
        {
            throw new Exception("Pet não pertence ao usuário");
        }
        
        var vet = await _vetRepository.GetVeterinaryById(requestDto.VetId);
        if (vet == null)
        {
            throw new Exception("Veterinário não existe");
        }

        if (vet.ClinicId != requestDto.ClinicId)
        {
            throw new Exception("Veterinário não pertence a clínica");
        }
        
        var appointment = await _appointmentRepository.GetAppointmentByClinicDateAndTime(requestDto.ClinicId, requestDto.VetId, requestDto.Date, requestDto.Time);
        
        if (appointment != null)
        {
            if (appointment.Status == StatusEnum.Scheduled)
            {
                throw new InvalidOperationException("Uma consulta ja existe nesse dia e horario para esse veterinario.");
            }
        }
        
        var newAppointment = new AppointmentScheduleContext(
            userId, 
            requestDto.PetId, 
            requestDto.ClinicId, 
            requestDto.VetId, 
            requestDto.Date, 
            requestDto.Time, 
            requestDto.SymptomDescription
        );
        
        await _appointmentRepository.CreateAsync(newAppointment);
        
        return newAppointment; 
    }
}