using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzzleMedBackend.Core.Contexts.Veterinarians.DTOs;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases
{
    public class GetVetsAllUseCase
    {
        private readonly IVetRepository _veterinarianRepository;

        public GetVetsAllUseCase(IVetRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public async Task<IEnumerable<VetDropdownOutputDto>> ExecuteGetAll()
        {
            var vets = await _veterinarianRepository.GetAll();

            return vets.Select(v => new VetDropdownOutputDto
            {
                Id = v.Id,
                FullName = v.Name.FullName
            });
        }
    }
}