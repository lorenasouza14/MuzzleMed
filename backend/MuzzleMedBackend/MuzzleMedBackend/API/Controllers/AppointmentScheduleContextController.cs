using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;
using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.API.Controllers;

[Controller]
[Authorize]
[Route("api/[controller]")]
public class AppointmentScheduleContextController : ControllerBase
{
    private readonly IGetUserIdService _getUserIdService;
    private readonly ICreateAppointmentUseCase _createAppointmentUseCase;
    private readonly IGetAppointmentsByUser _getAppointmentsByUserUseCase;
    private readonly IGetAppointmentById _getAppointmentByIdUseCase;

    public AppointmentScheduleContextController(ICreateAppointmentUseCase createAppointmentUseCase, IGetAppointmentsByUser getAppointmentsByUserUseCase, IGetUserIdService getUserIdService, IGetAppointmentById getAppointmentByIdUseCase)
    {
        _createAppointmentUseCase = createAppointmentUseCase;
        _getAppointmentsByUserUseCase = getAppointmentsByUserUseCase;
        _getUserIdService = getUserIdService;
        _getAppointmentByIdUseCase = getAppointmentByIdUseCase;
    }
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

    [HttpGet]
    public IActionResult GetAppointmentByUser()
    {
        var userId = _getUserIdService.GetUserId();
        var appoitments = _getAppointmentsByUserUseCase.ExecuteAsync(userId);
        
        return Ok(appoitments);
    }

    [HttpGet("{id}")]
    public IActionResult GetAppointmentById(Guid id)
    {
        var appointment = _getAppointmentByIdUseCase.Execute(id);
        return Ok(appointment);
    }
    
}