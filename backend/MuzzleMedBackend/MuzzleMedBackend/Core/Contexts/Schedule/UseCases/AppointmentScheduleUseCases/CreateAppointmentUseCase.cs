using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class CreateAppointmentUseCase : ICreateAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateAppointmentUseCase(IAppointmentRepository  appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public AppointmentScheduleContext Execute(CreateAppointmentDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));
            if(_appointmentRepository.FindAppointmentByDateAndTime(dto.Date, dto.Time) != null)
            {
                throw new Exception("Uma consulta ja existe nesse dia e horario");
            }

            var appointment = new AppointmentScheduleContext
            {
                ClinicId = dto.ClinicId,
                Date = dto.Date,
                Time = dto.Time,
                UserId = dto.UserId,
                VetId = dto.VetId,
                PetId = dto.PetId
            };
            
            _appointmentRepository.CreateAppointmentSchedule(appointment);
            return appointment;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}