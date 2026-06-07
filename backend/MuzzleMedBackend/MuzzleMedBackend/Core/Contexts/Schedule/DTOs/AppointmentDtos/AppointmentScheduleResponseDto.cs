namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

public class AppointmentScheduleResponseDto
{
    public String PetName { get; set; }
    public String VetName { get; set; }
    public String ClinicName { get; set; }
    
    public AppointmentScheduleResponseDto(){}

    public AppointmentScheduleResponseDto(String petName, String vetName, String clinicName)
    {
        PetName = petName;
        VetName = vetName;
        ClinicName = clinicName;
    }
}