using Lutra.Application.Customers.UseCases.CustomerDetailsInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lutra.Api.Controllers;

/// <summary>
/// Gestiona los detalles de facturación y perfil de los clientes.
/// </summary>
[ApiController]
[Authorize]
[Tags("Clientes")]
[Route("api/customers")]
[Produces("application/json")]
public class CustomerController : ControllerBase
{
    private readonly GetCustomerDetailsByUserUseCase _getCustomerDetailsByUser;
    private readonly UpsertCustomerDetailsInfoUseCase _upsertCustomerDetailsInfo;

    public CustomerController(
        GetCustomerDetailsByUserUseCase getCustomerDetailsByUser,
        UpsertCustomerDetailsInfoUseCase upsertCustomerDetailsInfo)
    {
        _getCustomerDetailsByUser = getCustomerDetailsByUser;
        _upsertCustomerDetailsInfo = upsertCustomerDetailsInfo;
    }

    /// <summary>Retorna los detalles de facturación y perfil de un usuario cliente.</summary>
    [HttpGet("{userId:guid}/details")]
    [EndpointSummary("Retorna los detalles del cliente por usuario")]
    [EndpointDescription("Retorna los detalles de facturación y personales asociados con el GUID del usuario proporcionado. Retorna 400 si no existe un registro de detalles.")]
    [ProducesResponseType(typeof(CustomerDetailsInfoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerDetailsByUser(Guid userId)
    {
        var response = await _getCustomerDetailsByUser.ExecuteAsync(userId);
        return Ok(response);
    }

    /// <summary>Crea o actualiza los detalles de facturación y perfil de un cliente.</summary>
    [HttpPut("details")]
    [EndpointSummary("Crea o actualiza los detalles del cliente")]
    [EndpointDescription("Crea un nuevo registro de detalles del cliente si no existe uno para el usuario, de lo contrario actualiza el registro existente. Retorna el estado guardado.")]
    [ProducesResponseType(typeof(CustomerDetailsInfoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpsertCustomerDetailsInfo([FromBody] CustomerDetailsInfoRequest request)
    {
        var response = await _upsertCustomerDetailsInfo.ExecuteAsync(request);
        return Ok(response);
    }
}
