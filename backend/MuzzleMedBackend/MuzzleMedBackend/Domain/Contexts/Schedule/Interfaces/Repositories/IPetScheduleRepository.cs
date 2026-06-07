namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;

using Domain.Contexts.Schedule.Entities;

public interface IPetScheduleRepository
{
    Task AddAsync(PetSchedule petSchedule);
    Task <PetSchedule> GetByIdAsync(Guid petScheduleId);
    Task <List<PetSchedule>> GetPetsByUser(Guid userId);
}