using System;

namespace MuzzleMedBackend.Domain.Contexts.Veterinarians
{
    public class ClinicIdValueObject
    {
        public Guid ClinicId { get; private set; }

        public ClinicIdValueObject(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("O ID da clínica não pode ser um GUID vazio.", nameof(value));
            }

            ClinicId = value;
        }
    }
}