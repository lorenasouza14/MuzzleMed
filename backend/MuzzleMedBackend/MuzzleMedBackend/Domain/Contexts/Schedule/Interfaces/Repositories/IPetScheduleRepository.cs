namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;

using Domain.Contexts.Schedule.Entities;

public interface IPetScheduleRepository
{
    Task AddAsync(PetSchedule petSchedule);
}