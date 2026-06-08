using Microsoft.EntityFrameworkCore;
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

    public async Task<PetSchedule> GetByIdAsync(Guid petScheduleId)
    {
        var pet = await _context.PetSchedules.FirstOrDefaultAsync(p => p.PetId == petScheduleId);
        return pet;
    }

    public async Task<List<PetSchedule>> GetPetsByUser(Guid userId)
    {
        var pets = await  _context.PetSchedules.Where(p => p.UserId == userId).ToListAsync();
        return pets; 
    }

    public void UpdateWithOutSave(PetSchedule petSchedule)
    {
        _context.PetSchedules.Update(petSchedule);
    }
}