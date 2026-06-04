namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;

using Domain.Contexts.Schedule.Entities;

public interface IUserScheduleRepository
{
    Task AddAsync(UserSchedule userSchedule);
    Task<UserSchedule?> GetByIdTrackingAsync(Guid userId);
}