namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Repositories;

using Microsoft.EntityFrameworkCore;
using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.Interfaces;

public class HistoricAppointmentRepository : IHistoricAppointmentRepository
{
    private readonly AppDbContext _context;

    public HistoricAppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HistoricAppointment?> GetByIdAsync(Guid id)
    {
        return await _context.HistoricAppointments
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<HistoricAppointment>> GetByPetIdAsync(Guid petId)
    {
        return await _context.Set<HistoricAppointment>()
            .AsNoTracking()
            .Where(h => h.PetId == petId)
            .OrderByDescending(h => h.Date)
            .ToListAsync();
    }

    public async Task CreateAsync(HistoricAppointment historic)
    {
        await _context.HistoricAppointments.AddAsync(historic);
        await _context.SaveChangesAsync();
    }
    
}