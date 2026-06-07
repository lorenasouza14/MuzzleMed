namespace MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using Domain.Contexts.Schedule.ValueObjects;

public class PetSchedule
{
    public Guid PetId { get; private set; }
    public string Name { get; private set; }
    public SpecieEnum Species { get; private set; }
    public Guid UserId { get; set; }

    protected PetSchedule() { }

    public PetSchedule(Guid petId, string name, SpecieEnum species, Guid userId)
    {
        if (petId == Guid.Empty)
            throw new ArgumentException("O ID do pet é inválido.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do pet é obrigatório.");

        PetId = petId;
        Name = name;
        Species = species;
        UserId = userId;
    }
}