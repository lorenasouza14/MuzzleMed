using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;
namespace MuzzleMedBackend.Core.Contexts.Veterinarians.DTOs
{
    public class VetRegisterInputDto
    {
        public string FullName { get; set; }
        public Guid ClinicId { get; set; }
    }
}
