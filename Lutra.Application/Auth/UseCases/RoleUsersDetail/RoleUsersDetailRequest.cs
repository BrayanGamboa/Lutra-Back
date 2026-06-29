using Lutra.Application.Auth.UseCases.Role;
using Lutra.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.RoleUsersDetail
{
    public record RoleUsersDetailRequest (string UserId, int RoleId);  
}   
