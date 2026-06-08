namespace MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;

using Domain.Contexts.Profile.Entities;

public interface IHistoricAppointmentRepository
{
    Task<HistoricAppointment?> GetByIdAsync(Guid id);
    Task<List<HistoricAppointment>> GetByPetIdAsync(Guid petId);
    Task CreateAsync(HistoricAppointment historic);
    public void AddWithOutSave(HistoricAppointment historic);

}