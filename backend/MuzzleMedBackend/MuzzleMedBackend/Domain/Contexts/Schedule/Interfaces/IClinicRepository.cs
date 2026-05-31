using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces
{
    public interface IClinicRepository
    {
        public void CreateClinic(Clinic clinic);
        public IEnumerable<Clinic> GetAllClinics();
    }
}
