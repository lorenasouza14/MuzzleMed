namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Repositories;

using Domain.Contexts.Schedule.Entities;
using Domain.Contexts.Schedule.Interfaces.Repositories;

public class PetScheduleRepository : IPetScheduleRepository
{
    private readonly AppDbContext _context;

    public PetScheduleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(PetSchedule petSchedule)
    {
        await _context.PetSchedules.AddAsync(petSchedule);
    }
}