namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Repositories;

using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
    }

    public async Task<IEnumerable<Pet>> GetActivePetsByUserIdAsync(Guid userId)
    {
        return await _context.Pets
            .AsNoTracking() // Melhora performance pois avisa o EF que não faremos Updates nesta consulta
            .Where(p => p.UserId == userId && p.IsActive)
            .ToListAsync();
    }
    
    public async Task<Pet?> GetByIdTrackingAsync(Guid id)
    {
        return await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
    }
}