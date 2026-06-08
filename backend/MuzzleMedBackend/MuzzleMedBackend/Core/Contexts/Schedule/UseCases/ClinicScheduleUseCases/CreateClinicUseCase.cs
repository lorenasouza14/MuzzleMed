using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases
{
    public class CreateClinicUseCase
    {
        private readonly IClinicRepository _clinicRepository;

        public CreateClinicUseCase(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

         public void Run(string name, string address)
            {

            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("O nome da Clínica é obrigatório.");
                }

                if (string.IsNullOrEmpty(address))
                {
                    throw new Exception("O endereço da Clínica é obrigatório.");
                }

                var clinic = new Clinic(name, address);
                _clinicRepository.CreateClinic(clinic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         }
    }
}
