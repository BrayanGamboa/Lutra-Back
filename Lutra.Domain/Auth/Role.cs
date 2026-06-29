using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Domain.Auth;

public class Role
{
    public int RoleId { get; set; }
    public string Name { get;  set; }
    public string Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Role() { }

    public static Role  Create(string name, string description)
    {
        return new Role
        {
            Name = name,
            Description = description,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(int roleId, string name, string description)
    {
        RoleId = roleId;
        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public virtual ICollection<RoleUsersDetail> RoleUsersDetails { get; set; } = new List<RoleUsersDetail>();
}

