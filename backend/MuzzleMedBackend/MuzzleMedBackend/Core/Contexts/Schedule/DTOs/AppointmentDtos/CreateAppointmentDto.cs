namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

public class CreateAppointmentDto
{
    public Guid UserId { get; set; }
    public Guid PetId { get; set; }
    public Guid ClinicId { get; set; }
    public Guid VetId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    
    public CreateAppointmentDto(Guid userId, Guid petId, Guid clinicId, Guid vetId, DateOnly date, TimeOnly time)
    {
        UserId = userId;
        PetId = petId;
        ClinicId = clinicId;
        VetId = vetId;
        Date = date;
        Time = time;
    }
}