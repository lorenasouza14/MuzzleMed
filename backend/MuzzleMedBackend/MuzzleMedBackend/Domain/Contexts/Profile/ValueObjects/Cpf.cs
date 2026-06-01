namespace MuzzleMedBackend.Domain.Contexts.Profile.ValueObjects;

public record Cpf
{
    public string Number { get; }

    public Cpf(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("O CPF não pode ser vazio.");

        var cleanCpf = number.Replace(".", "").Replace("-", "");
        
        if (cleanCpf.Length != 11 || !long.TryParse(cleanCpf, out _))
            throw new ArgumentException("O CPF deve conter 11 dígitos numéricos.");

        // Crio uma validação de CPF?
        Number = cleanCpf; 
    }
}