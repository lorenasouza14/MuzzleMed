using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentsByUserUseCase : IGetAppointmentsByUser
{
    private readonly IAppointmentRepository _appointmentRepository;
    public GetAppointmentsByUserUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    

    public List<AppointmentScheduleContext> ExecuteAsync(Guid userId)
    {
        return _appointmentRepository.GetAppointmentByUserIdSchedules(userId);
    }
}