namespace MuzzleMedBackend.Core.Contexts.Profile.DTOs;

public record HistoricResponse(
    Guid Id,
    Guid AppointmentId,
    DateOnly Date,
    string Diagnostic,
    List<string> Medication
);