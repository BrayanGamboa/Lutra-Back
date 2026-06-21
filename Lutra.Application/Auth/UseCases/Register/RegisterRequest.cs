using Lutra.Domain.Auth;


namespace Lutra.Application.Auth.UseCases.Register
{
    public record RegisterRequest(string Username, string Email, string Password, string Name, string LastName);
}
