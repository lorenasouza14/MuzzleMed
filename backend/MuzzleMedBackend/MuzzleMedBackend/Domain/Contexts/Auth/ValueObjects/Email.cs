using System.Text.RegularExpressions;

namespace MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;

public class Email
{
    public String Address { get; private set; }

    public Email(String address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentNullException(nameof(address), "Email address cannot be null or empty.");
        }

        if (!ValidateEmail(address))
        {
            throw new Exception("Invalid email format.");
        }

        Address = address.Trim().ToLower();
    }

    private bool ValidateEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
    }