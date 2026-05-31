using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;

namespace MuzzleMedBackend.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AppointmentScheduleContextController : ControllerBase
{
    private readonly ICreateAppointmentUseCase _createAppointmentUseCase;

    public AppointmentScheduleContextController(ICreateAppointmentUseCase createAppointmentUseCase)
    {
        _createAppointmentUseCase = createAppointmentUseCase;
    }
    [Authorize]
    [HttpPost("create")]
    public IActionResult Create(CreateAppointmentDto request)
    {
        try
        {
            var appointment = _createAppointmentUseCase.Execute(request);
            return Ok(appointment);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}