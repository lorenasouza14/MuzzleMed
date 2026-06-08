using MuzzleMedBackend.Core.Contexts.Profile.DTOs;
using MuzzleMedBackend.Domain.Contexts.Profile.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

public interface ICreateHistoricUseCase
{
    public bool Execute(CreateHistoricAppointmentRequestDto dto);
}