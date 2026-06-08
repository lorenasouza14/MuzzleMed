using MuzzleMedBackend.Core.Contexts.BookTime.DTOs;
using MuzzleMedBackend.Core.Contexts.Veterinarians.DTOs;
using MuzzleMedBackend.Domain.Contexts.BookTime.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Veterinarians;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Entities;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects;

namespace MuzzleMedBackend.Core.Contexts.BookTime.UseCases
{
    public class BookTimeUseCase
    {
        private readonly IBookTimeRepository _bookTimeRepository;


        public BookTimeUseCase(IBookTimeRepository bookTimeRepository)
        {
            _bookTimeRepository = bookTimeRepository;
        }

        public async Task<bool> RegisterBookTime(Guid userId, BookTimeInputDto bookTimeInput)
        {
            
            return await _bookTimeRepository.RegisterBookTime(
                userId,
                bookTimeInput.DateSchedule,
                bookTimeInput.TimeSchedule
            );
        }
    }
}
