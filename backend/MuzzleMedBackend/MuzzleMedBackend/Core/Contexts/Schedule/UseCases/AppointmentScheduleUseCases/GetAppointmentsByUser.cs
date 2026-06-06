using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentsByUser : IGetAppointmentsByUser
{
    private readonly IAppointmentRepository _appointmentRepository;
    public GetAppointmentsByUser(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    

    public List<AppointmentScheduleContext> ExecuteAsync(Guid userId)
    {
        return _appointmentRepository.GetAppointmentByUserIdSchedules(userId);
    }
}