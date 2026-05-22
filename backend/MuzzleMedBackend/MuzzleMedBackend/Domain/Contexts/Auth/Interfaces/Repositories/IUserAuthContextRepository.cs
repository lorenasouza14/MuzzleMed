using MuzzleMedBackend.Domain.Contexts.Auth.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;

public interface IUserAuthContextRepository
{
    public UserAuthContext GetByEmail(string email);
    public void SaveNewUserAuthContext(UserAuthContext userAuthContext);

}