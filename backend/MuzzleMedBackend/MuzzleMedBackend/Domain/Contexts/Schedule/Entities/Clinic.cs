namespace MuzzleMedBackend.Domain.Contexts.Schedule.Entities
{
    public class Clinic
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public Clinic(string name, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
        }
    }
}
