using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases; 
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentsByUserUseCase : IGetAppointmentsByUserUseCase 
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IGetUserIdService _getUserIdService;
    
    public GetAppointmentsByUserUseCase(
        IAppointmentRepository appointmentRepository, 
        IGetUserIdService getUserIdService)
    {
        _appointmentRepository = appointmentRepository;
        _getUserIdService = getUserIdService;
    }
    public async Task<List<AppointmentScheduleContext>?> ExecuteAsync()
    {
        var userId = _getUserIdService.GetUserId();
        
        var appointments = await _appointmentRepository.GetByUserIdAsync(userId);
        
        return appointments;
    }
}