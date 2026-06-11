using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.Login
{
    public record LoginRequest(string Username, string Password);
}
