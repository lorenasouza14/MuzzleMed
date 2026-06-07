namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public class DeletePetUseCase
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICheckFutureAppointmentsScheduleUseCase _scheduleIntegration;

    public DeletePetUseCase(
        IPetRepository petRepository, 
        IUnitOfWork unitOfWork,
        ICheckFutureAppointmentsScheduleUseCase scheduleIntegration)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
        _scheduleIntegration = scheduleIntegration;
    }

    public async Task ExecuteAsync(Guid petId, Guid userId)
    {
        var pet = await _petRepository.GetByIdTrackingAsync(petId);

        if (pet == null)
            throw new ArgumentException("Pet não encontrado.");

        if (pet.UserId != userId)
            throw new UnauthorizedAccessException("Você não tem permissão para alterar este pet.");

        if (!pet.IsActive)
            throw new ArgumentException("Este pet já foi removido.");

        bool hasFutureAppointments = await _scheduleIntegration.ExecuteAsync(petId);

        if (hasFutureAppointments)
            throw new InvalidOperationException("Não é possível remover o pet, pois existem consultas futuras agendadas.");

        pet.Deactivate();

        await _unitOfWork.CommitAsync();
    }
}