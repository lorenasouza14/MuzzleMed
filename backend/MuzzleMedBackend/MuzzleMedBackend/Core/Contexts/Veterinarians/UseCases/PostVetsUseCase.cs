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
          
            var clinicIdVo = new ClinicIdValueObject(input.ClinicId);
            var vetIdVo = new VetIdValueObject(Guid.NewGuid());
            var nameVo = new VetFullNameValueObject(input.FullName);
            var veterinary = new Veterinary(vetIdVo, nameVo, clinicIdVo);
            await _vetRepository.RegisterVeterinary(veterinary);
        }
    }
}
