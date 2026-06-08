using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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