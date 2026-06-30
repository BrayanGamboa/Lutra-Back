using Lutra.Application.Sales.UseCases.Sale;
using Lutra.Application.Sales.UseCases.SaleDetail;
using Lutra.Application.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lutra.Api.Controllers;

/// <summary>
/// Manages sales and their line-item details.
/// </summary>
[ApiController]
[Authorize]
[Tags("Ventas")]
[Route("api/sales")]
[Produces("application/json")]
public class SalesController : ControllerBase
{
    private readonly GetAllSalesUseCase _getAllSales;
    private readonly GetSaleByIdUseCase _getSaleById;
    private readonly GetSalesByCustomerUseCase _getSalesByCustomer;
    private readonly CreateSaleUseCase _createSale;
    private readonly UpdateSaleStatusUseCase _updateSaleStatus;
    private readonly GetSaleDetailsBySaleUseCase _getSaleDetailsBySale;
    private readonly GetSaleDetailByIdUseCase _getSaleDetailById;
    private readonly CreateSaleDetailUseCase _createSaleDetail;
    private readonly DeleteSaleDetailUseCase _deleteSaleDetail;

    public SalesController(
        GetAllSalesUseCase getAllSales,
        GetSaleByIdUseCase getSaleById,
        GetSalesByCustomerUseCase getSalesByCustomer,
        CreateSaleUseCase createSale,
        UpdateSaleStatusUseCase updateSaleStatus,
        GetSaleDetailsBySaleUseCase getSaleDetailsBySale,
        GetSaleDetailByIdUseCase getSaleDetailById,
        CreateSaleDetailUseCase createSaleDetail,
        DeleteSaleDetailUseCase deleteSaleDetail)
    {
        _getAllSales = getAllSales;
        _getSaleById = getSaleById;
        _getSalesByCustomer = getSalesByCustomer;
        _createSale = createSale;
        _updateSaleStatus = updateSaleStatus;
        _getSaleDetailsBySale = getSaleDetailsBySale;
        _getSaleDetailById = getSaleDetailById;
        _createSaleDetail = createSaleDetail;
        _deleteSaleDetail = deleteSaleDetail;
    }

    /// <summary>Retorna las ventas filtradas por el alcance del rol del llamador.</summary>
    [HttpGet]
    [EndpointSummary("Obtener todas las ventas")]
    [EndpointDescription(
        "Retorna las ventas según el rol más permisivo del usuario autenticado. " +
        "Administrador/Contador: todas las ventas. Supervisor: todas (alcance del equipo pendiente). " +
        "Vendedor: todas (campo de vendedor pendiente). Cliente: solo sus propias ventas. Inventario: 403. " +
        "Filtros de consulta opcionales: clienteId, vendedorId (pendiente), fechaDesde, fechaHasta.")]
    [ProducesResponseType(typeof(IEnumerable<SaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllSales(
        [FromQuery] Guid? clienteId = null,
        [FromQuery] Guid? vendedorId = null,
        [FromQuery] DateTime? fechaDesde = null,
        [FromQuery] DateTime? fechaHasta = null)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
        var userContext = new CurrentUserContext(userId, roles);
        var filters = new SaleFilters(clienteId, vendedorId, fechaDesde, fechaHasta);
        var response = await _getAllSales.ExecuteAsync(userContext, filters);
        return Ok(response);
    }

    /// <summary>Retorna una única venta por su identificador.</summary>
    [HttpGet("{id:guid}")]
    [EndpointSummary("Obtener venta por ID")]
    [EndpointDescription("Retorna la venta que coincide con el GUID proporcionado.")]
    [ProducesResponseType(typeof(SaleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSaleById(Guid id)
    {
        var response = await _getSaleById.ExecuteAsync(id);
        return Ok(response);
    }

    /// <summary>Retorna todas las ventas pertenecientes a un cliente específico.</summary>
    [HttpGet("by-customer/{customerId:guid}")]
    [EndpointSummary("Obtener ventas por cliente")]
    [EndpointDescription("Retorna todas las ventas asociadas con el GUID del cliente proporcionado.")]
    [ProducesResponseType(typeof(IEnumerable<SaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSalesByCustomer(Guid customerId)
    {
        var response = await _getSalesByCustomer.ExecuteAsync(customerId);
        return Ok(response);
    }

    /// <summary>Crea una venta.</summary>
    [HttpPost]
    [EndpointSummary("Crear venta")]
    [EndpointDescription("Registra una nueva venta para el cliente especificado. Retorna la venta creada con su ID generado.")]
    [ProducesResponseType(typeof(SaleResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateSale([FromBody] SaleRequest request)
    {
        var response = await _createSale.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetSaleById), new { id = response.SaleId }, response);
    }

    /// <summary>Actualiza el estado de una venta existente.</summary>
    [HttpPatch("{id:guid}/status")]
    [EndpointSummary("Actualizar estado de venta")]
    [EndpointDescription("Transiciona la venta identificada por el GUID a un nuevo valor de estado. Retorna 400 si la venta no existe.")]
    [ProducesResponseType(typeof(SaleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSaleStatus(Guid id, [FromBody] UpdateSaleStatusRequest request)
    {
        var response = await _updateSaleStatus.ExecuteAsync(id, request);
        return Ok(response);
    }

    /// <summary>Retorna todos los detalles de una venta específica.</summary>
    [HttpGet("{saleId:guid}/details")]
    [EndpointSummary("Obtener detalles de venta por venta")]
    [EndpointDescription("Retorna la lista completa de detalles de línea (productos, cantidades, precios) que pertenecen a la venta especificada.")]
    [ProducesResponseType(typeof(IEnumerable<SaleDetailResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSaleDetailsBySale(Guid saleId)
    {
        var response = await _getSaleDetailsBySale.ExecuteAsync(saleId);
        return Ok(response);
    }

    /// <summary>Retorna un único detalle de venta por su identificador entero.</summary>
    [HttpGet("details/{id:int}")]
    [EndpointSummary("Obtener detalle de venta por ID")]
    [EndpointDescription("Retorna el registro de detalle de venta que coincide con el ID entero proporcionado. Retorna 400 si no se encuentra.")]
    [ProducesResponseType(typeof(SaleDetailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSaleDetailById(int id)
    {
        var response = await _getSaleDetailById.ExecuteAsync(id);
        return Ok(response);
    }

    /// <summary>Agrega un detalle de línea a una venta.</summary>
    [HttpPost("details")]
    [EndpointSummary("Crear detalle de venta")]
    [EndpointDescription("Agrega un nuevo detalle de línea de producto a una venta existente. Retorna el detalle creado con su ID generado.")]
    [ProducesResponseType(typeof(SaleDetailResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateSaleDetail([FromBody] SaleDetailRequest request)
    {
        var response = await _createSaleDetail.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetSaleDetailById), new { id = response.SaleDetailId }, response);
    }

    /// <summary>Elimina un detalle de línea de venta.</summary>
    [HttpDelete("details/{id:int}")]
    [EndpointSummary("Eliminar detalle de venta")]
    [EndpointDescription("Elimina permanentemente el registro de detalle de venta identificado por el ID entero. Retorna 400 si no se encuentra.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSaleDetail(int id)
    {
        await _deleteSaleDetail.ExecuteAsync(id);
        return NoContent();
    }
}
