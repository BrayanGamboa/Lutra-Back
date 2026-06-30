using Lutra.Application.Auth.Ports;
using Lutra.Application.Auth.UseCases.RoleUsersDetail;
using Lutra.Domain.Shared;

namespace Lutra.Application.Auth.UseCases.Login;
public class LoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenManager _tokenManager;
    private readonly IPasswordHasher _passwordHasher;
    private readonly RoleUsersDetailUseCase _roleUsersDetailRepository;

    public LoginUseCase(
        IUserRepository userRepository,
        ITokenManager tokenManager,
        IPasswordHasher passwordHasher,
        RoleUsersDetailUseCase roleUsersDetailUseCase)
    {
        _userRepository = userRepository;
        _tokenManager = tokenManager;
        _passwordHasher = passwordHasher;
        _roleUsersDetailRepository = roleUsersDetailUseCase;
    }

    public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username)
            ?? throw new DomainException("Credenciales inválidas");

        if (!user.IsActive)
            throw new DomainException("Usuario inactivo");

        if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
            throw new DomainException("Credenciales inválidas");

        var userWithRol = await _roleUsersDetailRepository.GetRoleUsersDetailAsync(user.UserId);
        var roleNames = userWithRol.Roles.Select(r => r.Name).ToList();

        var token = _tokenManager.GenerateToken(user, roleNames);

        return new LoginResponse(token, userWithRol);
    }
}
