using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;

namespace MuzzleMedBackend.API.Controllers;

[Controller]
[Authorize]
[Route("api/[controller]")]
public class AppointmentScheduleContextController : ControllerBase
{
    private readonly ICreateAppointmentUseCase _createAppointmentUseCase;
    private readonly IGetAppointmentsByUserUseCase _getAppointmentsByUserUseCase;
    private readonly IGetAppointmentByIdUseCase _getAppointmentByIdUseCase;
    private readonly ICancelAppointmentScheduleUseCase _cancelAppointmentScheduleUseCase;
    private readonly IFinalizeAppointmentUseCase _finalizeAppointmentUseCase;

    public AppointmentScheduleContextController(ICreateAppointmentUseCase createAppointmentUseCase,
        IGetAppointmentsByUserUseCase getAppointmentsByUserUseCase,
        IGetAppointmentByIdUseCase getAppointmentByIdUseCase,
        ICancelAppointmentScheduleUseCase cancelAppointmentScheduleUseCase,
        IFinalizeAppointmentUseCase finalizeAppointmentUseCase)
    {
        _createAppointmentUseCase = createAppointmentUseCase;
        _getAppointmentsByUserUseCase = getAppointmentsByUserUseCase;
        _getAppointmentByIdUseCase = getAppointmentByIdUseCase;
        _cancelAppointmentScheduleUseCase = cancelAppointmentScheduleUseCase;
        _finalizeAppointmentUseCase = finalizeAppointmentUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentRequestDto request)
    {
        var appointment = await _createAppointmentUseCase.ExecuteAsync(request);
        return Ok(appointment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAppointmentsByUser()
    {
        var appointments = await _getAppointmentsByUserUseCase.ExecuteAsync();
        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentById([FromRoute] Guid id)
    {
        var appointment = await _getAppointmentByIdUseCase.ExecuteAsync(id);

        return Ok(appointment);
    }

    [HttpPut("cancel/{id}")]
    public async Task<IActionResult> CancelAppointmentById([FromRoute] Guid id)
    {
        var appointment = await _cancelAppointmentScheduleUseCase.ExecuteAsync(id);
        return Ok("Agendamento cancelado com sucesso");
    }

    [HttpPut("finalize/{id}")]
    public async Task<IActionResult> FinalizeAppointmentById([FromRoute] Guid id,
        [FromBody] FinalizeAppointmentRequestDto dto)
    {
        await _finalizeAppointmentUseCase.ExecuteAsync(id, dto);
        var finalizeAgendamento = new FinalizeAppointmentResponse(dto.Diagnostic, dto.Medications);
         
        return Ok(finalizeAgendamento);
    }

}