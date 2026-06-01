namespace MuzzleMedBackend.Domain.Contexts.Profile.ValueObjects;

public record Email
{
    public string Address { get; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("O email não pode ser vazio.");
        
        if (!address.Contains("@") || !address.Contains("."))
            throw new ArgumentException("O email informado é inválido.");

        Address = address;
    }
}