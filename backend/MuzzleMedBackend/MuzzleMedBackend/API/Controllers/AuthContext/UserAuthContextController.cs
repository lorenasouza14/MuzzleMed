using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Auth.DTOs;
using MuzzleMedBackend.Core.Contexts.Auth.UseCases;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.UseCases;

namespace MuzzleMedBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAuthContextController : ControllerBase
{
    private readonly ILoginUseCase _loginUseCase;
    
    public UserAuthContextController(LoginUseCase loginUseCase)
    {
        _loginUseCase = loginUseCase;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        try    
        {
            var response = _loginUseCase.Execute(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}