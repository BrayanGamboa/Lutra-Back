using Lutra.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.Register
{
    public record UserResponse(Guid UserId, string Username, string Email, string Name, string LastName, DateTime CreatedAt, DateTime? UpdatedAt, DateTime? LastLoginAt, bool IsActive)
    {
        public static UserResponse FromDomain(Domain.Auth.User user) =>
            new(user.UserId, user.Username, user.Email, user.Name, user.LastName, user.CreatedAt, user.UpdatedAt, user.LastLoginAt, user.IsActive);
    };
}   