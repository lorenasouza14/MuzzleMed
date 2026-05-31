namespace MuzzleMedBackend.Domain.Contexts.Veterinarians.ValueObjects
{
    public class VetFullNameValueObject
    {
        public string FullName { get; set; }

        public VetFullNameValueObject(string fullName)
        {
            if (fullName == null) { 
                throw new ArgumentNullException(nameof(fullName)); 
            }

            FullName = fullName;

        }
    }
}

        
  