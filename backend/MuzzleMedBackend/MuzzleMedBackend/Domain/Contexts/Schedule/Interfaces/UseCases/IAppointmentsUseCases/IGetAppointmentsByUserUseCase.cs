using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IGetAppointmentsByUserUseCase
{
    Task<List<AppointmentResponseDto>?> ExecuteAsync();
}