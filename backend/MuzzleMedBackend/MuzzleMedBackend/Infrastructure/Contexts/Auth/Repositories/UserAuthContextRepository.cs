using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;
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
        var searchEmail = new Email(email);
        return _context.UsersAuth.FirstOrDefault(
            u => 
                u.EmailAuthContext == searchEmail);
    }

    public void SaveNewUserAuthContext(UserAuthContext userAuthContext)
    {
        _context.UsersAuth.Add(userAuthContext);
        // O salvamento será feito pelo UnitOfWork no final do UseCase principal por isso tirei o Savechanges
    }
}