using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class DeleteAppointmentScheduleUseCase : IDeleteAppointmentScheduleUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;

    public DeleteAppointmentScheduleUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    
    public AppointmentScheduleContext Execute(DeleteAppointmentDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var id = dto.id;
        return _appointmentRepository.DeleteAppointmentSchedule(id);
    }
}