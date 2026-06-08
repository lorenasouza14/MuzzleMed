namespace MuzzleMedBackend.Core.Contexts.Profile.UseCases;

using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

public class DeletePetUseCase
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICheckFutureAppointmentsScheduleUseCase _scheduleIntegration;
    private readonly IDeletePetScheduleUseCase _deletePetScheduleUseCase;

    public DeletePetUseCase(
        IPetRepository petRepository, 
        IUnitOfWork unitOfWork,
        ICheckFutureAppointmentsScheduleUseCase scheduleIntegration, IDeletePetScheduleUseCase deletePetScheduleUseCase)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
        _scheduleIntegration = scheduleIntegration;
        _deletePetScheduleUseCase = deletePetScheduleUseCase;
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
        var updatePetSchedule = await _deletePetScheduleUseCase.ExecuteAsync(petId);
        if (!updatePetSchedule)
        {
            throw new Exception("Ocorreu um erro ao tentar remover o pet do sistema de agendamento. Tente novamente mais tarde.");
        }

        await _unitOfWork.CommitAsync();
    }
}