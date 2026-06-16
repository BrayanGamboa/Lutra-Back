using Lutra.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.Ports
{
    public interface ITokenManager
    {
        string GenerateToken(User user);
    }
}
