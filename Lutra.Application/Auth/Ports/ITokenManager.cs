using Lutra.Domain.Auth;

namespace Lutra.Application.Auth.Ports
{
    public interface ITokenManager
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}
