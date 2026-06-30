using Lutra.Application.Auth.UseCases.Login;
using Lutra.Application.Auth.UseCases.Register;
using Lutra.Application.Auth.UseCases.Role;
using Lutra.Application.Auth.UseCases.RoleUsersDetail;
using Microsoft.AspNetCore.Mvc;

namespace Lutra.Api.Controllers;

[ApiController]
[Tags("Autenticación y roles")]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly LoginUseCase _loginUseCase;
    private readonly RegisterUseCase _registerUseCase;
    private readonly RoleUseCase _roleUseCase;
    private readonly RoleUsersDetailUseCase _roleUsersDetailUseCase;

    public AuthController(LoginUseCase loginUseCase, RegisterUseCase registerUseCase, RoleUseCase roleUseCase, RoleUsersDetailUseCase roleUsersDetailUseCase)
    {
        _loginUseCase = loginUseCase;
        _registerUseCase = registerUseCase;
        _roleUseCase = roleUseCase;
        _roleUsersDetailUseCase = roleUsersDetailUseCase;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _loginUseCase.ExecuteAsync(request);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await _registerUseCase.ExecuteAsync(request);
        return Ok(response);
    }

    #region Role 

    [HttpPost("role")]
    public async Task<IActionResult> CreateRole([FromBody] RoleRequest request)
    {
        var response = await _roleUseCase.ExecuteAsync(request);
        return Ok(response);
    }

    [HttpGet("role")]
    public async Task<IActionResult> GetRoleByName([FromQuery] string roleName, int? roleId = null)
    {
        var response = await _roleUseCase.GetByNameAsync(roleName, roleId);
        return Ok(response);
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var response = await _roleUseCase.GetAllAsync();
        return Ok(response);
    }

    [HttpPatch("role/{roleId:int}")]
    public async Task<IActionResult> UpdateRole([FromBody] RoleRequest request, int roleId)
    {
        var response = await _roleUseCase.UpdateAsync(roleId, request);
        return Ok(response);
    }

    [HttpDelete("role/{roleId:int}")]
    public async Task<IActionResult> DeleteRole(int roleId)
    {
        await _roleUseCase.DeleteAsync(roleId);
        return NoContent();
    }


    #endregion Role


    [HttpGet("user/roles")]
    public async Task<IActionResult> GetRolesByUserId([FromQuery] Guid userId)
    {
        var response = await _roleUsersDetailUseCase.GetRoleUsersDetailAsync(userId);
        return Ok(response);
    }

    [HttpPost("user/roles")]
    public async Task<IActionResult> AssignRoleToUser([FromBody] RoleUsersDetailRequest request)
    {
        var response = await _roleUsersDetailUseCase.AddRoleToUserAsync(Guid.Parse(request.UserId), request.RoleId);
        return Ok(response);
    }
}