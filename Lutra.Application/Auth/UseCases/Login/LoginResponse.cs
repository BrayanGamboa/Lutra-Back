using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.Login
{
    public record LoginResponse(string Token, string Username, string Role);
}
