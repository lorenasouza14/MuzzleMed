using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Infrastructure.Persistence;

namespace MuzzleMedBackend.Infrastructure.Contexts.Auth.Repositories;

public class UserAuthContextRepository : IUserAuthContextRepository
{
    private readonly AuthDbContext _context;
    
    public UserAuthContextRepository(AuthDbContext context)
    {
        _context = context;
    }
    public UserAuthContext GetByEmail(string email)
    {
        return _context.UsersAuth.FirstOrDefault(
            u => 
                u.EmailAuthContext.ToString() == email.Trim().ToLower());
    }

    public void SaveNewUserAuthContext(UserAuthContext userAuthContext)
    {
        _context.UsersAuth.Add(userAuthContext);
        _context.SaveChanges();
    }
}