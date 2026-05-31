using static MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects.ClinicValueObject;

namespace MuzzleMedBackend.Domain.Contexts.Schedule.Entities
{
    public class Clinic
    {
        public ClinicId Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Clinic(string name, string address)
        {
            Id = ClinicId.New();
            Name = name;
            Address = address;
        }
    }
}
