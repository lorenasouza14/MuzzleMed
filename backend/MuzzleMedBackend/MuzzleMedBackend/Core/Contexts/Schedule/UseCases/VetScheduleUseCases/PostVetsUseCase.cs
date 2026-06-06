using MuzzleMedBackend.Core.Contexts.Veterinarians.DTOs;
using MuzzleMedBackend.Domain.Contexts.Veterinarians;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;
using System.Threading.Tasks;

namespace MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases
{
    public class PostVetsUseCase
    {
        private readonly IVetRepository _vetRepository;

        public PostVetsUseCase(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }

        public async Task ExecuteRegisterVeterinary(VetRegisterInputDto input)
        {
          
            var clinicId = input.ClinicId;
            var vetId = new Guid();
            var nameVo = new VetFullNameValueObject(input.FullName);
            var veterinary = new Veterinary(vetId, nameVo, clinicId);
            await _vetRepository.RegisterVeterinary(veterinary);
        }
    }
}
