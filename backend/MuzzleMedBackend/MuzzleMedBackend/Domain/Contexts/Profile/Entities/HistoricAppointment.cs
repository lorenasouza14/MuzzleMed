namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;

public class HistoricAppointment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid AppointmentId { get; set; }
    
    // Suportado nativamente no EF Core 8 (Primitive Collections)
    public List<string> Medication { get; set; } = new();
    public string Diagnostic { get; set; } = string.Empty;
}