using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Domain.Contexts.Profile.Entities;

public class HistoricAppointment
{
    public Guid Id { get; private set; }
    public Guid AppointmentId { get; private set; }
    public Guid PetId { get; private set; }
    public String PetName { get; private set; }
    public Guid ClinicId { get; private set; }
    public String  ClinicName { get; private set; }
    public Guid VetId { get; private set; }
    public VetFullNameValueObject VetName { get; private set; }
    
    public DateOnly Date { get; private set; }
    
    public string SymptomDescription { get; private set; }
    public string Diagnostic { get; private set; }
    public List<string> Medication { get; private set; }

    protected HistoricAppointment() { }

    public HistoricAppointment(Guid appointmentId, Guid petId, DateOnly date, string diagnostic, List<string> medication,
        Guid clinicId, Guid vetId,  string symptomDescription, String petName, String clinicName, VetFullNameValueObject vetName)
    {
        Id = Guid.NewGuid();
        AppointmentId = appointmentId;
        PetId = petId;
        ClinicId = clinicId;
        VetId = vetId;
        Date = date;
        SymptomDescription = symptomDescription;
        Diagnostic = diagnostic;
        Medication = medication;
        PetName = petName;
        ClinicName = clinicName;
        VetName = vetName;
    }
}