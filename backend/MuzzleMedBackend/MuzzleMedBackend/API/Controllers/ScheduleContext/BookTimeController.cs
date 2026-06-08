using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.BookTime.DTOs;
using MuzzleMedBackend.Core.Contexts.BookTime.UseCases;

namespace MuzzleMedBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class BookTimeController : ControllerBase
    {
        private readonly BookTimeUseCase _postBookTimeUseCase;

        public BookTimeController(BookTimeUseCase postBookTimeUseCase)
        {
            _postBookTimeUseCase = postBookTimeUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] BookTimeInputDto model)
        {
           
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized(new { message = "Usuário não identificado no token." });
            }

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return BadRequest(new { message = "ID de usuário inválido." });
            }

            bool sucesso = await _postBookTimeUseCase.RegisterBookTime(userId, model);

            if (!sucesso)
            {
                return BadRequest(new { message = "Este horário já foi reservado por outro usuário ou seu tempo esgotou." });
            }

            return Ok(new { message = "Horário pré-reservado com sucesso por 10 minutos!" });
        }
    }
}