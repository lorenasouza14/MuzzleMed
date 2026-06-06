namespace MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects
{
    public class VetIdValueObject
    {
        public Guid VetId { get; set; }

        public VetIdValueObject(Guid vetId)
        {
            if (vetId == Guid.Empty)
            {
                throw new ArgumentException("O ID do Veterinario não pode ser um GUID vazio.", nameof(vetId));
            }

            VetId = vetId;
        }
    }
}
