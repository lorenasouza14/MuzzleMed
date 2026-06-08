using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

public class CreateHistoricAppointmentRequestDto
{
    public Guid AppointmentId { get; set; }
    public Guid UserId { get; set; }
    public Guid PetId { get; set; }
    public String PetName { get; set; }
    public Guid ClinicId { get; set; }
    public String ClinicName { get; set; }
    public Guid VetId { get; set; }
    public string VetName { get; set; }
    public DateOnly Date { get; set; }
    public String SymptomDescription { get; set; }
    public string Diagnostic { get; set; }
    public List<string> Medication { get; set; }
}