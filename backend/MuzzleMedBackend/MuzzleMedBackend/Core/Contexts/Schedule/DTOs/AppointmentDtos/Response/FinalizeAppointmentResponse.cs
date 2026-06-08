namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

public class FinalizeAppointmentResponse
{
    public String Diagnostic { get; set; }
    public List<String> Medication { get; set; }
    
    
    public FinalizeAppointmentResponse(){ }
    
    
    public FinalizeAppointmentResponse(String diagnostic, List<String> medication){
        Diagnostic = diagnostic;
        Medication = medication;
    }
}
