using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities
{
    public class Veterinary
    {
        public Guid Id { get; private set; }
        public VetFullNameValueObject Name { get; private set; }
        public Guid ClinicId { get; private set; }

        public Veterinary(Guid vetId, VetFullNameValueObject vetName, Guid clinicId)
        {
            Id = vetId;
            Name = vetName;
            ClinicId = clinicId;
        }

        protected Veterinary() { }
    }
}