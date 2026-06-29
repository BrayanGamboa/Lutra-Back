using Lutra.Application.Auth.UseCases.Role;
using Lutra.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.RoleUsersDetail
{
    public record RoleUsersDetailResponse (Guid UserId, string Username, string Email, string Name, string LastName, IEnumerable<RoleResponse> Roles)
    {
        public static RoleUsersDetailResponse FromDomain(Domain.Auth.User user, IEnumerable<Domain.Auth.RoleUsersDetail> roles) =>
            new(user.UserId, user.Username, user.Email, user.Name, user.LastName, roles.Select(r => RoleResponse.FromDomain(r.Role)));
    }
}   
