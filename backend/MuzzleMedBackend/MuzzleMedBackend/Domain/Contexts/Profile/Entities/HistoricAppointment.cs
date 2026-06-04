namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;

public class HistoricAppointment
{
    public Guid Id { get; private set; }
    public Guid AppointmentId { get; private set; }
    public Guid PetId { get; private set; } 
    public DateOnly Date { get; private set; } 
    public string Diagnostic { get; private set; }
    public List<string> Medication { get; private set; }

    protected HistoricAppointment() { }

    public HistoricAppointment(Guid appointmentId, Guid petId, DateOnly date, string diagnostic, List<string> medication)
    {
        Id = Guid.NewGuid();
        AppointmentId = appointmentId;
        PetId = petId;
        Date = date;
        Diagnostic = diagnostic;
        Medication = medication;
    }
}