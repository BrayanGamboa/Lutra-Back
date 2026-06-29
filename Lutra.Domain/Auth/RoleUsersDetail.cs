using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lutra.Domain.Auth
{
    public class RoleUsersDetail
    {
        public int RoleUserDetailId { get; set; }

        public Guid UserId { get; set; }

        public int RoleId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual Role Role { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        public void CreateRoleUsersDetail(Guid userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
