using MuzzleMedBackend.Services.Interfaces;

namespace MuzzleMedBackend.API.Controllers.ProfileContext;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Contexts.Profile.UseCases;
using Core.Contexts.Profile.DTOs;

[Authorize]
[ApiController]
[Route("api/v1/pets")]

public class PetProfileContextController : ControllerBase
{
    private readonly IGetUserIdService _getUserIdService;

    public PetProfileContextController(IGetUserIdService getUserIdService)
    {
        _getUserIdService = getUserIdService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePetRequest request,
        [FromServices] CreatePetUseCase useCase)
    {
        try
        {
            var userId = _getUserIdService.GetUserId();
            
            await useCase.ExecuteAsync(request, userId);
            
            return StatusCode(201, new { Message = "Pet cadastrado com sucesso" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByUser([FromServices] GetPetsByUserUseCase useCase)
    {
        var userId = _getUserIdService.GetUserId();

        var pets = await useCase.ExecuteAsync(userId);

        return Ok(pets);
    }
    
    [HttpGet("{petId}/history")]
    public async Task<IActionResult> GetHistory(
        [FromRoute] Guid petId,
        [FromServices] GetPetHistoryUseCase useCase)
    {
        try
        {
            var userId = _getUserIdService.GetUserId();

            var history = await useCase.ExecuteAsync(petId, userId);
            
            return Ok(history);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Forbid(ex.Message);
        }
    }
    
    [HttpDelete("{petId}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid petId,
        [FromServices] DeletePetUseCase useCase)
    {
        try
        {
            Guid userId = _getUserIdService.GetUserId();

            await useCase.ExecuteAsync(petId, userId);

            return Ok(new { Message = "Pet removido com sucesso." }); 
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
        catch (InvalidOperationException ex) 
        {
            return BadRequest(new { Error = ex.Message }); 
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { Error = ex.Message }); 
        }
    }
}