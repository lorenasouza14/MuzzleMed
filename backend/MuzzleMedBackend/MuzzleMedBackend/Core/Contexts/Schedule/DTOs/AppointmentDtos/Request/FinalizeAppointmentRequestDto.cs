namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

public class FinalizeAppointmentRequestDto
{
    public String Diagnostic { get; set; }
    public List<String> Medications { get; set; }
}