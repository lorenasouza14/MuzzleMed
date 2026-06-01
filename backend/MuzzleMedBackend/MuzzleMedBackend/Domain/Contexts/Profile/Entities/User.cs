namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.ValueObjects;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public Email ProfileEmail { get; private set; }
    public Cpf Cpf { get; private set; }
    public Phone Phone { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public List<Pet> Pets { get; private set; } = new();

    // Construtor vazio necessário apenas para o EF Core fazer o mapeamento interno
    protected User() { }

    // Construtor principal usado pela sua aplicação (UseCases)
    public User(string fullName, Email email, Cpf cpf, Phone phone, DateTime dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("O nome completo é obrigatório.");

        if (dateOfBirth > DateTime.UtcNow)
            throw new ArgumentException("A data de nascimento não pode estar no futuro.");

        Id = Guid.NewGuid();
        FullName = fullName;
        ProfileEmail = email;
        Cpf = cpf;
        Phone = phone;
        DateOfBirth = dateOfBirth;
    }
}