namespace MuzzleMedBackend.API.Controllers.ProfileContext;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Contexts.Profile.UseCases;
using Core.Contexts.Profile.DTOs;

[ApiController]
[Route("api/v1/pets")]
[Authorize] // EXIGE TOKEN JWT PARA ACESSAR QUALQUER ROTA DESTA CONTROLLER
public class PetProfileContextController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePetRequest request,
        [FromServices] CreatePetUseCase useCase)
    {
        try
        {
            // Extrai o ID do usuário de dentro do Token JWT decodificado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized(new { Error = "Token inválido ou ID de usuário não encontrado." });

            // Executa passando o DTO e o ID seguro
            await useCase.ExecuteAsync(request, userId);
            
            return StatusCode(201, new { Message = "Pet cadastrado com sucesso" });
        }
        catch (ArgumentException ex)
        {
            // Erros de regra de negócio do construtor da Entidade
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByUser([FromServices] GetPetsByUserUseCase useCase)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new { Error = "Token inválido ou ID de usuário não encontrado." });

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
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized(new { Error = "Token inválido ou ID de usuário não encontrado." });

            var history = await useCase.ExecuteAsync(petId, userId);
            
            return Ok(history);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Forbid(ex.Message); // HTTP 403: Proibido
        }
    }
}