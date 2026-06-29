using Lutra.Application.Auth.Ports;
using Lutra.Domain.Auth;
using Lutra.Domain.Shared;

namespace Lutra.Application.Auth.UseCases.User;

public class UserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserUseCase(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserResponse> GetUserById(Guid? userId, string email)
    {
        var user = await _userRepository.GetByEmailOrUserIdAsync(email, userId);

        if (user == null)
        {
            throw new DomainException("User not found");
        }

        return UserResponse.FromDomain(user);
    }

    public async Task<UserResponse> UpdateUserAsync(Guid userId, UserRequest request)
    {
        var user = await _userRepository.GetByEmailOrUserIdAsync(request.Email, userId) ?? throw new DomainException("User not found");

        var hashedPassword = _passwordHasher.Hash(request.Password);

        user.Update(userId, request.Username, request.Email, hashedPassword, request.Name, request.LastName);

        await _userRepository.UpdateAsync(user);
        return UserResponse.FromDomain(user);
    }
}
