using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentById : IGetAppointmentById
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentById(IAppointmentRepository appointmentRepository)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(appointmentRepository);
            _appointmentRepository = appointmentRepository;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }


    public AppointmentScheduleContext? Execute(Guid id)
    {
        return _appointmentRepository.GetAppointmentById(id);
    }
}