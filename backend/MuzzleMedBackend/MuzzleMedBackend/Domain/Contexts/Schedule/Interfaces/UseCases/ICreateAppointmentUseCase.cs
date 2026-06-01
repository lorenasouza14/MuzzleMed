using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;

public interface ICreateAppointmentUseCase
{
    public AppointmentScheduleContext Execute(CreateAppointmentDto dto);
}