using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.Role
{
    public record RoleResponse(
    int RoleId,
    string Name,
    string Description,
    DateTime? CreatedAt,
    DateTime? UpdatedAt)
    {
        public static RoleResponse FromDomain(Domain.Auth.Role role) =>
            new(role.RoleId, role.Name, role.Description, role.CreatedAt, role.UpdatedAt);
    }
}
