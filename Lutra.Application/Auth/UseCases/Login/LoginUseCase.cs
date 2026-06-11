using Lutra.Application.Auth.Ports;
using Lutra.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.UseCases.Login;
public class LoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenManager _tokenManager;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUseCase(
        IUserRepository userRepository,
        ITokenManager tokenManager,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _tokenManager = tokenManager;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username)
            ?? throw new DomainException("Credenciales inválidas");

        if (!user.IsActive)
            throw new DomainException("Usuario inactivo");

        if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
            throw new DomainException("Credenciales inválidas");

        var token = _tokenManager.Generate(user);

        return new LoginResponse(token, user.Username, user.Role);
    }
}
