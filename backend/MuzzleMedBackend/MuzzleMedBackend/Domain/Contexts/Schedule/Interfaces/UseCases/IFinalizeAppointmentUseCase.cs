using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public interface IFinalizeAppointmentUseCase
{
    Task<FinalizeAppointmentResponse> ExecuteAsync(Guid appointmentId, FinalizeAppointmentRequestDto dto);
}