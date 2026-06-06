using System.Runtime.InteropServices.JavaScript;
using MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.Enums;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

public class AppointmentScheduleContext
{
    public Guid Id { get; private set; }
    public Guid UserId { get; set; }
    public Guid PetId { get; set; }
    public Guid ClinicId { get; set; }
    public Guid VetId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public StatusEnum Status { get; set; }
    public string Symptoms { get; set; }

    public AppointmentScheduleContext(Guid userId, Guid petId, Guid clinicId, Guid vetId, DateOnly date, TimeOnly time)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        PetId = petId;
        ClinicId = clinicId;
        VetId = vetId;
        Date = date;
        Time = time;
        Status = StatusEnum.Scheduled;
    }

    public AppointmentScheduleContext()
    {
    }
}