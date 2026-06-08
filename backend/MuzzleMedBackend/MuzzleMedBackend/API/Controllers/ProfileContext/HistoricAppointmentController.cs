using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Profile.DTOs;
using MuzzleMedBackend.Core.Contexts.Schedule.DTOs.HistoricAppointment;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;

namespace MuzzleMedBackend.API.Controllers;

[Controller]
[Authorize]
[Route("api/[controller]")]
public class HistoricAppointmentController : ControllerBase
{
    private readonly ICreateHistoricUseCase _createHistoricUseCase;
    private readonly IGetHistoricByIdUseCase _getHistoricByIdUseCase;
    private readonly IGetHistoricByPetUseCase _getHistoricByPetUseCase;


    public HistoricAppointmentController(ICreateHistoricUseCase createHistoricUseCase,
        IGetHistoricByIdUseCase getHistoricByIdUseCase,
        IGetHistoricByPetUseCase getHistoricByPetUseCase)
    {
        _createHistoricUseCase = createHistoricUseCase;
        _getHistoricByIdUseCase = getHistoricByIdUseCase;
        _getHistoricByPetUseCase = getHistoricByPetUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHistoricDto dto)
    {
        try
        {
            var historic = await _createHistoricUseCase.ExecuteAsync(dto);

            // Retorna 201 Created (Padrão ouro do REST para POST)
            return CreatedAtAction(nameof(GetById), new { id = historic.Id }, historic);
        }
        catch (InvalidOperationException ex) // Captura falhas de regras de negócio
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var historic = await _getHistoricByIdUseCase.executeAsync(id);

        return Ok(historic);
    }

    [HttpGet("pet/{petId}")]
    public async Task<IActionResult> GetByPetId([FromRoute] Guid petId)
    {
        var historics = await _getHistoricByPetUseCase.ExecuteAsync(petId);
        return Ok(historics);
    }
}