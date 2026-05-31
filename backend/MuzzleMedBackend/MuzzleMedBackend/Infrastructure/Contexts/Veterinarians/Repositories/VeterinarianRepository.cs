using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Domain.Contexts.Veterinarians;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Infrastructure.Persistence;
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Repositories;

public class VeterinarianRepository : IVetRepository
{
    private readonly VeterinaryDbContext _context;

    public VeterinarianRepository(VeterinaryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Veterinary>> GetAll()
    {
        var allVets = await _context.Veterinarians.ToListAsync();
        return allVets;
    }


    public async Task<IEnumerable<Veterinary>> GetVetsByClinicId(ClinicIdValueObject clinicId)
    {
        var vetsByClinic = await _context.Veterinarians.Where(v => v.ClinicId.ClinicId == clinicId.ClinicId)
            .ToListAsync();
        
        return vetsByClinic;
    }

    public async Task RegisterVeterinary(Veterinary veterinarian)
    {
        await _context.Veterinarians.AddAsync(veterinarian);
        await _context.SaveChangesAsync();
    }
}