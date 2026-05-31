using Microsoft.AspNetCore.Mvc;
using MuzzleMedBackend.Core.Contexts.Schedule.DTOs;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using static MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.ClinicValueObject;

namespace MuzzleMedBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _repository;
        public ClinicController(IClinicRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateClinicRequestDTO request)
        {
            var novaClinica = new Clinic(request.Name, request.Address);
            _repository.CreateClinic(novaClinica);

            return Ok(novaClinica);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clinicas = _repository.GetAllClinics();
            return Ok(clinicas);
        }
    }
}