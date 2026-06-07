namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs.HistoricAppointment;

public class CreateHistoricDto
{
    public Guid AppointmentId { get; set; }
    public Guid PetId { get; set; }
    public DateOnly Date { get; set; }
    public string Diagnostic { get; set; }
    public List<string> Medication { get; set; }
}
