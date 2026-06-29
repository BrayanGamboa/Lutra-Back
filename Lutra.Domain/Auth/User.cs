using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Domain.Auth;

public class User
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }
    public bool IsActive { get; private set; }

    private User() { }

    public static User Create(
        string username, string email, string passwordHash,
        string name, string lastName)
    {
        return new User
        {
            UserId = Guid.NewGuid(),
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
            Name = name,
            LastName = lastName,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(
        Guid userId, string username, string email, string passwordHash,
        string name, string lastName)
    {
        UserId = userId;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Name = name;
        LastName = lastName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLastLogin()
    {
        LastLoginAt = DateTime.UtcNow;
    }

    public void Deactivate() => IsActive = false;

    public virtual ICollection<RoleUsersDetail> RoleUsersDetails { get; set; } = new List<RoleUsersDetail>();

}

