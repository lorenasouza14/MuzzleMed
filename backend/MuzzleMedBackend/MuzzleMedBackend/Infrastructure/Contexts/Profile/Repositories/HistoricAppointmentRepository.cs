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

    public async Task<IEnumerable<HistoricAppointment>> GetByPetIdAsync(Guid petId)
    {
        return await _context.Set<HistoricAppointment>()
            .AsNoTracking()
            .Where(h => h.PetId == petId)
            .OrderByDescending(h => h.Date)
            .ToListAsync();
    }
}