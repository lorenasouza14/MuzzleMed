using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases; // Assumindo o namespace correto da interface

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

// Nome da classe corrigido (removido o 'UseCaseUseCase' duplicado)
public class GetAppointmentByIdUseCase : IGetAppointmentByIdUseCase 
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentByIdUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public async Task<AppointmentScheduleContext?> ExecuteAsync(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        
        var appointment = await _appointmentRepository.GetByIdAsync(id);
        
        return appointment; 
    }
    
}