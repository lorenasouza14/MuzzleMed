namespace MuzzleMedBackend.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Contexts.Profile.UseCases;
using Core.Contexts.Profile.DTOs;
using MuzzleMedBackend.Services.Interfaces; 

[ApiController]
[Route("api/v1/users")]
public class UserProfileContextController : ControllerBase
{
    private readonly IGetUserIdService _getUserIdService;

    // Injeção do serviço via construtor
    public UserProfileContextController(IGetUserIdService getUserIdService)
    {
        _getUserIdService = getUserIdService;
    }

    [HttpPost]
    [AllowAnonymous]
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
            Guid userId = _getUserIdService.GetUserId();

            var userProfile = await useCase.ExecuteAsync(userId);
            return Ok(userProfile);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
    }
    
    [HttpPut("user")]
    [Authorize]
    public async Task<IActionResult> UpdateProfile(
        [FromBody] UpdateUserRequest request,
        [FromServices] UpdateUserUseCase useCase)
    {
        try
        {
            Guid userId = _getUserIdService.GetUserId();

            await useCase.ExecuteAsync(userId, request);
            
            return NoContent(); 
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}