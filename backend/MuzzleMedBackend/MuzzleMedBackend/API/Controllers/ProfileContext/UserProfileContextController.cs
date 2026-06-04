namespace MuzzleMedBackend.API.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Contexts.Profile.UseCases;
using Core.Contexts.Profile.DTOs;

[ApiController]
[Route("api/v1/users")]
public class UserProfileContextController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous] // Indica que não precisa de token JWT para esta rota
    public async Task<IActionResult> Create(
        [FromBody] CreateUserRequest request,
        [FromServices] CreateUserUseCase useCase)
    {
        try
        {
            await useCase.ExecuteAsync(request);
            
            return StatusCode(201, new { Message = "Usuário criado com sucesso" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    [HttpGet("user")]
    [Authorize] 
    public async Task<IActionResult> GetProfile([FromServices] GetUserProfileUseCase useCase)
    {
        try
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized(new { Error = "Token inválido ou ID de usuário não encontrado." });

            var userProfile = await useCase.ExecuteAsync(userId);
            return Ok(userProfile);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
    }
}