using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Core.Contexts.Schedule.DTOs;

public class AppointmentScheduleResponseDto
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Status { get; set; } 
    
    public Guid ClinicId { get; set; }
    public string ClinicName { get; set; } 
    
    public Guid VetId { get; set; }
    public VetFullNameValueObject VetName { get; set; }
    
    public Guid PetId { get; set; }
    public string PetName { get; set; }
    
}