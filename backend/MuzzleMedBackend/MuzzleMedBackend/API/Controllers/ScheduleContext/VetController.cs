using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Veterinarians.DTOs;
using MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases;

namespace MuzzleMedBackend.API.Controllers
{
    [ApiController]
    public class VetsController : ControllerBase
    {
        private readonly GetVetsAllUseCase _getVetsAllUseCase;
        private readonly GetVetsByClinicIdUseCase _getVetsByClinicIdUseCase;
        private readonly PostVetsUseCase _postVetsUseCase;

        public VetsController(GetVetsAllUseCase getVetsAllUseCase, GetVetsByClinicIdUseCase getVetsByClinicIdUseCase, PostVetsUseCase postVetsUseCase)
        {
            _getVetsAllUseCase = getVetsAllUseCase;
            _getVetsByClinicIdUseCase = getVetsByClinicIdUseCase;
            _postVetsUseCase = postVetsUseCase;
        }

        [HttpGet("/api/vets")]
        public async Task<ActionResult> GetVetsAll() {
            var vets = await _getVetsAllUseCase.ExecuteGetAll();
            return Ok(vets);
        }

        [HttpGet("/api/vets/{clinicId}")]
        public async Task<ActionResult> GetVetsByClinicId([FromRoute] Guid clinicId){
            var inputDto = new VetByClinicInputDto { ClinicId = clinicId };
            var vets = await _getVetsByClinicIdUseCase.ExecuteGetVetsByClinicId(inputDto);
            return Ok(vets);
        }

        [HttpPost("/api/vets/register")]
        public async Task<ActionResult> RegisterVeterinary([FromBody] VetRegisterInputDto inputVetDto){
            await _postVetsUseCase.ExecuteRegisterVeterinary(inputVetDto);

            return Created(string.Empty, new { message = "Veterinário cadastrado com sucesso!" });
        
        }
    }
}