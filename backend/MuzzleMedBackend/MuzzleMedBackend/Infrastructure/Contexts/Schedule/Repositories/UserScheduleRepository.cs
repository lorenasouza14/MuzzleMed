namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Repositories;

using Domain.Contexts.Schedule.Entities;
using Domain.Contexts.Schedule.Interfaces.Repositories;

public class UserScheduleRepository : IUserScheduleRepository
{
    private readonly AppDbContext _context;

    public UserScheduleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserSchedule userSchedule)
    {
        await _context.UserSchedules.AddAsync(userSchedule);
    }
}