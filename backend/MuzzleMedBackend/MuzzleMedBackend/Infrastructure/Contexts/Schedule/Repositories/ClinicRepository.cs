using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Schedule.Entities;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

namespace MuzzleMedBackend.Infrastructure.Contexts.Schedule.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly AppDbContext _context;

        public ClinicRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
        }

        public IEnumerable<Clinic> GetAllClinics()
        {
            return _context.Clinics.ToList();
        }

        public async Task<Clinic> GetClinicById(Guid clinicId)
        {
            var clinic = await _context.Clinics.FirstOrDefaultAsync(x => x.Id == clinicId);
            return clinic;
        }
    }
}
