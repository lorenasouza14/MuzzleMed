using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;

namespace MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces
{
    public interface IVetRepository
    {
        Task<IEnumerable<Veterinary>> GetVetsByClinicId(Guid clinicId);
        Task<IEnumerable<Veterinary>> GetAll();
        Task RegisterVeterinary(Veterinary veterinarian);
        Task<Veterinary> GetVeterinaryById(Guid id);
    }
       
}
