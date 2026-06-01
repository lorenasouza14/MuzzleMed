namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;
using Domain.Contexts.Profile.ValueObjects;

public class Pet
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public SpecieEnum Specie { get; private set; }
    public string Breed { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public GenderEnum Gender { get; private set; }
    public Guid UserId { get; private set; }
    public bool IsActive { get; private set; }
    public User User { get; private set; } = null!;

    protected Pet() { }

    public Pet(string name, SpecieEnum specie, string breed, DateTime dateOfBirth, GenderEnum gender, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do pet é obrigatório.");

        if (dateOfBirth > DateTime.UtcNow)
            throw new ArgumentException("A data de nascimento não pode estar no futuro.");

        if (userId == Guid.Empty)
            throw new ArgumentException("O ID do usuário (tutor) é inválido.");

        Id = Guid.NewGuid();
        Name = name;
        Specie = specie;
        Breed = string.IsNullOrWhiteSpace(breed) ? "MND (Mistura Não Definida)" : breed;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        UserId = userId;
        IsActive = true;
    }
}