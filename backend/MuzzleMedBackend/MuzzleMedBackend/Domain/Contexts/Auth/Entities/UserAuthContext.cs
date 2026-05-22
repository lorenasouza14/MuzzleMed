using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;

namespace MuzzleMedBackend.Domain.Contexts.Auth.Entities;

public class UserAuthContext
{
    public Guid Id { get; private set; }
    public Email EmailAuthContext { get; set; }
    public String PasswordHash { get; set; }
    
    protected UserAuthContext() { }
    public UserAuthContext(Email email, string password)
    {
        Id = Guid.NewGuid();
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


