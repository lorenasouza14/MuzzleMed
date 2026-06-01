namespace MuzzleMedBackend.Infrastructure.Contexts.Profile.Repositories;

using Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.Interfaces;

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
}