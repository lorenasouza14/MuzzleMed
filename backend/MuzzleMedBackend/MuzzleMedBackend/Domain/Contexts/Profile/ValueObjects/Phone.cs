namespace MuzzleMedBackend.Domain.Contexts.Profile.ValueObjects;

public record Phone
{
    public string Number { get; }

    public Phone(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("O telefone não pode ser vazio.");

        var cleanPhone = number.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

        if (cleanPhone.Length < 10 || cleanPhone.Length > 11)
            throw new ArgumentException("O telefone deve conter entre 10 e 11 dígitos com DDD.");

        Number = cleanPhone;
    }
}