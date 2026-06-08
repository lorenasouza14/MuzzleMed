namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

public class CreateAppointmentRequestDto
{ 
    public Guid PetId { get; set; }
    public Guid ClinicId { get; set; }
    public Guid VetId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string SymptomDescription { get; set; }
    
    
    public CreateAppointmentRequestDto(){}
    
    public CreateAppointmentRequestDto(Guid petId, Guid clinicId, Guid vetId,
        DateOnly date, TimeOnly time, string symptomDescription)
    {
        PetId = petId;
        ClinicId = clinicId;
        VetId = vetId;
        Date = date;
        Time = time;

        SymptomDescription = symptomDescription;
    }
}