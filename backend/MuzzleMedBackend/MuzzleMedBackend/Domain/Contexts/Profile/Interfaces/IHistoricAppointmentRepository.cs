namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;

using Domain.Contexts.Profile.Entities;

public interface IHistoricAppointmentRepository
{
    Task<IEnumerable<HistoricAppointment>> GetByPetIdAsync(Guid petId);
}