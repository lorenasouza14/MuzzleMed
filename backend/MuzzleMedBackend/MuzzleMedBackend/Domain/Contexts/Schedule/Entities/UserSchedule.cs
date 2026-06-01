namespace MuzzleMedBackend.Domain.Contexts.Schedule.Entities;

public class UserSchedule
{
    // A chave primária aqui é o próprio UserId gerado no Profile Context
    public Guid UserId { get; private set; }
    public string FullName { get; private set; }
    public string Phone { get; private set; } // Como já foi validado antes, não validei aqui tb

    protected UserSchedule() { }

    public UserSchedule(Guid userId, string fullName, string phone)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("O ID do usuário é inválido.");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("O nome completo é obrigatório.");

        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("O telefone é obrigatório.");

        UserId = userId;
        FullName = fullName;
        Phone = phone;
    }
}