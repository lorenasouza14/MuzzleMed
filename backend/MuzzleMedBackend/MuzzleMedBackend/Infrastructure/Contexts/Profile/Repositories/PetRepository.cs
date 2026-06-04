namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Repositories;

using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.Interfaces;

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
}