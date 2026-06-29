using Lutra.Domain.Auth;


namespace Lutra.Application.Auth.UseCases.User
{
    public record UserRequest(string Username, string Email, string Password, string Name, string LastName);
}
