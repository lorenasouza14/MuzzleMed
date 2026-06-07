using MuzzleMedBackend.Core.Contexts.Schedule.DTOs.HistoricAppointment;
using MuzzleMedBackend.Domain.Contexts.Profile.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

public interface ICreateHistoricUseCase
{
    Task<HistoricAppointment> ExecuteAsync(CreateHistoricDto dto);
}