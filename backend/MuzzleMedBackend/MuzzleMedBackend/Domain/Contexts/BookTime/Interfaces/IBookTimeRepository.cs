namespace MuzzleMedBackend.Domain.Contexts.BookTime.Interfaces
{
    public interface IBookTimeRepository
    {
        Task<List<string>> GetBookedTimesByDate(string dateSchedule);
        Task ReleaseBookTime(Guid userId, string dateSchedule, string timeSchedule);
        Task<bool> RegisterBookTime(Guid userId, string dateSchedule, string timeSchedule);


    }
}