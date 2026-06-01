namespace MuzzleMedBackend.Core.Contexts.BookTime.DTOs
{
    public class BookTimeInputDto
    {
        public Guid UserId { get; set; }
        public string DateSchedule { get; set; }
        public string TimeSchedule { get; set; }
    }
}
