namespace MuzzleMedBackend.API.Controllers;

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
}