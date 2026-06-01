namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;

public class HistoricAppointment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid AppointmentId { get; set; }
    
    public List<string> Medication { get; set; } = new();
    public string Diagnostic { get; set; } = string.Empty;
}