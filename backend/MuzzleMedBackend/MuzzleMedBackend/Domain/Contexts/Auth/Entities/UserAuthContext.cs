using System.ComponentModel.DataAnnotations;
using MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;

namespace MuzzleMedBackend.Domain.Contexts.Auth.Entities;

public class UserAuthContext
{
    public Guid Id { get; private set; }
    public Email EmailAuthContext { get; private set; }
    public string PasswordHash { get; private set; }
    
    protected UserAuthContext() { }
    public UserAuthContext(Guid id, Email email, string password)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id inválido");

        Id = id; 
        EmailAuthContext = email;
        SetPasswordAsHash(password);
    }
    private void SetPasswordAsHash(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        {
            throw new ArgumentException("Password required at least 6 digits");
        }
        
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool ValidatePassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }
}


