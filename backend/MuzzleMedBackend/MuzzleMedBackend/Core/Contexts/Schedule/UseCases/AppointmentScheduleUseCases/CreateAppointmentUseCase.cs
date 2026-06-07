using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class CreateAppointmentUseCase : ICreateAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IGetUserIdService _getUserIdService;
    private readonly IPetScheduleRepository _petScheduleRepository;
    private readonly IUserScheduleRepository _userScheduleRepository;

    public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository, IGetUserIdService getUserIdService, IPetScheduleRepository petScheduleRepository, IUserScheduleRepository userScheduleRepository)
    {
        _appointmentRepository = appointmentRepository;
        _getUserIdService = getUserIdService;
        _petScheduleRepository = petScheduleRepository;
        _userScheduleRepository = userScheduleRepository;
    }
    public async Task<AppointmentScheduleContext> ExecuteAsync(CreateAppointmentDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        
        var existingAppointment = await _appointmentRepository.GetByDateAndTimeAsync(dto.Date, dto.Time);
        
        if (existingAppointment != null)
        {
            throw new InvalidOperationException("Uma consulta ja existe nesse dia e horario.");
        }

        if (existingAppointment.Status == StatusEnum.Canceled || existingAppointment.Status == StatusEnum.Completed)
        {
            throw new InvalidOperationException("Consulta já cancelada ou completa");
        }
        
        var userId = _getUserIdService.GetUserId(); 
        
        var appointment = new AppointmentScheduleContext(
            userId, 
            dto.PetId, 
            dto.ClinicId, 
            dto.VetId, 
            dto.Date, 
            dto.Time, 
            dto.SymptomDescription
        );
        
        await _appointmentRepository.CreateAsync(appointment);
        
        return appointment; 
    }
}