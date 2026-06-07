namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Repositories;

using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
    
    public async Task<bool> ExistsByCpfAsync(string cpf)
    {
        return await _context.Users.AnyAsync(u => u.Cpf.Number == cpf);
    }
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<User?> GetByIdTrackingAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}