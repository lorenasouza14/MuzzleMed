using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases; // Assumindo que a interface está aqui
using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class CancelAppointmentScheduleUseCase : ICancelAppointmentScheduleUseCase // Lembre-se de mudar para Task na interface!
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CancelAppointmentScheduleUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
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
        
        appointment.Cancel();
        
        await _appointmentRepository.UpdateAsync(appointment);
        
        return appointment;
    }
}