using Lutra.Application.Auth.Ports;
using Microsoft.Extensions.Configuration;

namespace Lutra.Infrastructure.Security;



public class BcryptPasswordHasher : IPasswordHasher
{
    private readonly string _keyToken;

    public BcryptPasswordHasher(IConfiguration configuration)
    {
        _keyToken = configuration["Jwt:Secret"];
    }

    public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);
}