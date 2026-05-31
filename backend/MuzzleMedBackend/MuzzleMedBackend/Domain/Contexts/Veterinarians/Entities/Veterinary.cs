using System;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities
{
    public class Veterinary
    {
        public VetIdValueObject Id { get; private set; }
        public VetFullNameValueObject Name { get; private set; }
        public ClinicIdValueObject ClinicId { get; private set; }

        public Veterinary(VetIdValueObject vetId, VetFullNameValueObject vetName, ClinicIdValueObject clinicId)
        {
            Id = vetId ?? throw new ArgumentNullException(nameof(vetId), "O ID do veterinário é obrigatório.");
            Name = vetName ?? throw new ArgumentNullException(nameof(vetName), "O nome do veterinário é obrigatório.");
            ClinicId = clinicId ?? throw new ArgumentNullException(nameof(clinicId), "O ID da clínica é obrigatório.");
        }

        protected Veterinary() { }
    }
}