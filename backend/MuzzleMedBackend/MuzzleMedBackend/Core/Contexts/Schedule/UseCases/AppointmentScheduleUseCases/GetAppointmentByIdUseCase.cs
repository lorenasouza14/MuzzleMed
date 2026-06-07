using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentByIdUseCase : IGetAppointmentById
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentByIdUseCase(IAppointmentRepository appointmentRepository)
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


    public AppointmentScheduleContext? Execute(GetApointmentByIdDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        
        var id = dto.Id;
        
        return _appointmentRepository.GetAppointmentById(id);
    }

}