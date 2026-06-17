using DevOpsDashboard.Domain.Common;

namespace DevOpsDashboard.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public string Role { get; private set; } = "Admin";

    private User()
    {
    }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }
}