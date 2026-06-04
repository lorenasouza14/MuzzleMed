namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.ValueObjects;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public Email ProfileEmail { get; private set; }
    public Cpf Cpf { get; private set; }
    public Phone Phone { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public List<Pet> Pets { get; private set; } = new();

    protected User() { }

    public User(string fullName, Email email, Cpf cpf, Phone phone, DateOnly dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("O nome completo é obrigatório.");

        if (dateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("A data de nascimento não pode estar no futuro.");

        Id = Guid.NewGuid();
        FullName = fullName;
        ProfileEmail = email;
        Cpf = cpf;
        Phone = phone;
        DateOfBirth = dateOfBirth;
    }
    
    public void UpdateProfile(string fullName, Phone phone, DateOnly dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("O nome não pode ser vazio.");

        if (dateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("A data de nascimento não pode estar no futuro.");

        FullName = fullName;
        Phone = phone;
        DateOfBirth = dateOfBirth;
    }
}