using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.BookTime.DTOs;
using MuzzleMedBackend.Core.Contexts.BookTime.UseCases;
using MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases;

namespace MuzzleMedBackend.API.Controllers
{
 
    [ApiController]
    public class BookTimeController : ControllerBase
    {
        private readonly BookTimeUseCase _postBookTimeUseCase;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] BookTimeInputDto model) {
            bool sucesso = await _postBookTimeUseCase.RegisterBookTime(model);

            if (!sucesso){
                return BadRequest(new { message = "Este horário já foi reservado por outro usuário ou seu tempo esgotou." });
            }

            return Ok(new { message = "Horário pré-reservado com sucesso por 10 minutos!" });
        }
    }
    }

