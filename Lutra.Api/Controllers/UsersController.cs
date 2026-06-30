using Lutra.Application.Auth.UseCases.User;
using Lutra.Application.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lutra.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/usuarios")]
[Produces("application/json")]
[Tags("Usuarios")]
public class UsersController(GetAllUsersUseCase getAllUsers) : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Listar usuarios")]
    [EndpointDescription(
        "Retorna usuarios paginados con filtros opcionales. " +
        "'search' filtra por nombre, apellido o username (parcial, case-insensitive). " +
        "'rol' filtra usuarios que tengan ese rol entre sus roles.")]
    [ProducesResponseType(typeof(PagedResult<UserListItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? search = null,
        [FromQuery] string? rol = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var response = await getAllUsers.ExecuteAsync(search, rol, page, pageSize);
        return Ok(response);
    }
}
