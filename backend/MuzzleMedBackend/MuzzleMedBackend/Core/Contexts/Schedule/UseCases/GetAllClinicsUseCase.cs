using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;

namespace MuzzleMedBackend.Core.Contexts.Schedule.UseCases
{
    public class GetAllClinicsUseCase
    {
        private readonly IClinicRepository _clinicRepository;

        public GetAllClinicsUseCase(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public IEnumerable<Clinic> Run()
        {
            try
            {
                return _clinicRepository.GetAllClinics();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
