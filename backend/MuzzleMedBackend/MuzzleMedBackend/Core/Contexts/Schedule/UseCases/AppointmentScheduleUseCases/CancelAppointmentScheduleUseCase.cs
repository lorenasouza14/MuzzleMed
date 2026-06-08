using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases; 
using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class CancelAppointmentScheduleUseCase : ICancelAppointmentScheduleUseCase 
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IGetUserIdService _getUserIdService;

    public CancelAppointmentScheduleUseCase(IAppointmentRepository appointmentRepository, IGetUserIdService getUserIdService)
    {
        _appointmentRepository = appointmentRepository;
        _getUserIdService = getUserIdService;
    }
    public async Task<AppointmentScheduleContext> ExecuteAsync(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        
        var appointment = await _appointmentRepository.GetByIdAsync(id);

        if (appointment == null)
        {
            throw new InvalidOperationException("agendamento não encontrado.");
        }
        
        if (appointment.Status == StatusEnum.Completed || appointment.Status == StatusEnum.Canceled)
        {
            throw new InvalidOperationException("agendamento ja concluído ou cancelado.");
        }

        if (appointment.UserId != _getUserIdService.GetUserId())
        {
            throw new InvalidOperationException("agendamento não pertence ao usuário logado");
        }
        appointment.Cancel();
        
        await _appointmentRepository.UpdateAsync(appointment);
        
        return appointment;
    }
}