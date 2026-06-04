namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using Domain.Contexts.Profile.Interfaces;
using Core.Contexts.Profile.DTOs;

public class GetPetHistoryUseCase
{
    private readonly IPetRepository _petRepository;
    private readonly IHistoricAppointmentRepository _historicRepository;

    public GetPetHistoryUseCase(
        IPetRepository petRepository, 
        IHistoricAppointmentRepository historicRepository)
    {
        _petRepository = petRepository;
        _historicRepository = historicRepository;
    }

    public async Task<IEnumerable<HistoricResponse>> ExecuteAsync(Guid petId, Guid userId)
    {
        // Validação de segurança: O pet existe e pertence a este tutor?
        var pet = await _petRepository.GetByIdTrackingAsync(petId);
        
        if (pet == null || pet.UserId != userId)
        {
            throw new UnauthorizedAccessException("Pet não encontrado ou não pertence a você.");
        }

        var history = await _historicRepository.GetByPetIdAsync(petId);

        return history.Select(h => new HistoricResponse(
            h.Id,
            h.AppointmentId,
            h.Date,
            h.Diagnostic,
            h.Medication
        ));
    }
}