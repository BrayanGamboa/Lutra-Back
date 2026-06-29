using Lutra.Application.Auth.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Auth.UseCases.Register;

public class RegisterUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUseCase(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserResponse> ExecuteAsync(RegisterRequest request)
    {
        var userExists = await _userRepository.ExistAsync(request.Email, request.Username);

        if (userExists)
        {
            throw new DomainException("El usuario ya existe");
        }

        var hashedPassword = _passwordHasher.Hash(request.Password);

        var user = Domain.Auth.User.Create(
            request.Username,
            request.Email,
            hashedPassword,
            request.Name,
            request.LastName
        );
        await _userRepository.AddAsync(user);

        return UserResponse.FromDomain(user);
    }
}
