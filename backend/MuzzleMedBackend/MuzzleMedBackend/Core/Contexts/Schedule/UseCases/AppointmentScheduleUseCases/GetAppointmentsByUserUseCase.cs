using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;

public class GetAppointmentsByUserUseCase : IGetAppointmentsByUserUseCase 
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IGetUserIdService _getUserIdService;
    private readonly IVetRepository _vetRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IPetScheduleRepository _petScheduleRepository;
    private readonly IBuildAppointmentResponseUseCase _buildAppointmentResponseUseCase;
    
    public GetAppointmentsByUserUseCase(
        IAppointmentRepository appointmentRepository, 
        IGetUserIdService getUserIdService, IVetRepository vetRepository, IClinicRepository clinicRepository, IPetScheduleRepository petScheduleRepository, IBuildAppointmentResponseUseCase buildAppointmentResponseUseCase)
    {
        _appointmentRepository = appointmentRepository;
        _getUserIdService = getUserIdService;
        _vetRepository = vetRepository;
        _clinicRepository = clinicRepository;
        _petScheduleRepository = petScheduleRepository;
        _buildAppointmentResponseUseCase = buildAppointmentResponseUseCase;
    }

    public async Task<List<AppointmentScheduleResponseDto>?> ExecuteAsync()
    {
        var userId = _getUserIdService.GetUserId();
        
        var appointments = await _appointmentRepository.GetByUserIdAsync(userId);
        
        var responseList = new List<AppointmentScheduleResponseDto>();

        if (appointments == null)
            return responseList;
        
        foreach (var a in appointments)
        {
            var app = await _buildAppointmentResponseUseCase.ExecuteAsync(a);
            responseList.Add(app);
        }
        return responseList;
    }
}
