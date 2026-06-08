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
    private readonly IBuildAppointmentResponseUseCase _buildAppointmentResponseUseCase;

    public GetAppointmentByIdUseCase(IAppointmentRepository appointmentRepository, IClinicRepository clinicRepository, IVetRepository vetRepository, IPetScheduleRepository petScheduleRepository, IBuildAppointmentResponseUseCase buildAppointmentResponseUseCase)
    {
        _appointmentRepository = appointmentRepository;
        _clinicRepository = clinicRepository;
        _vetRepository = vetRepository;
        _petScheduleRepository = petScheduleRepository;
        _buildAppointmentResponseUseCase = buildAppointmentResponseUseCase;
    }
    public async Task<AppointmentScheduleResponseDto?> ExecuteAsync(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        
        var appointment = await _appointmentRepository.GetByIdAsync(id);
        
        if (appointment == null) 
            return null;

        return await _buildAppointmentResponseUseCase.ExecuteAsync(appointment);
    }
    
}