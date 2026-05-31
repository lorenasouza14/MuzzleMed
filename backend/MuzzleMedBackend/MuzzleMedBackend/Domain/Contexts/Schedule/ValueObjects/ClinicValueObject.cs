namespace MuzzleMedBackend.Domain.Contexts.Schedule.ValueObjects
{
    public class ClinicValueObject
    {
        public readonly record struct ClinicId(Guid Value)
        {
            public static ClinicId New() => new(Guid.NewGuid());
        }
    }
}
