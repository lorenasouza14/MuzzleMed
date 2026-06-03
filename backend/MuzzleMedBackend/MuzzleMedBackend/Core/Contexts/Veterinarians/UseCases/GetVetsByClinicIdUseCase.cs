using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzzleMedBackend.Core.Contexts.Veterinarians.DTOs; 
using MuzzleMedBackend.Domain.Contexts.Veterinarians;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases
{
    public class GetVetsByClinicIdUseCase
    {
        private readonly IVetRepository _veterinarianRepository;

        public GetVetsByClinicIdUseCase(IVetRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public async Task<IEnumerable<VetDropdownOutputDto>> ExecuteGetVetsByClinicId(VetByClinicInputDto input)
        {
            var clinicIdVo = input.ClinicId;
            var vets = await _veterinarianRepository.GetVetsByClinicId(clinicIdVo);

            return vets.Select(vet => new VetDropdownOutputDto
            {
            
                Id = vet.Id,
                FullName = vet.Name.FullName
            });
        }
    }
}