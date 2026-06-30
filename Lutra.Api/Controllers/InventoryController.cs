using Lutra.Application.Inventory.UseCases.Category;
using Lutra.Application.Inventory.UseCases.Supplier;
using Lutra.Application.Inventory.UseCases.ReferencesType;
using Lutra.Application.Inventory.UseCases.InventoryMovement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lutra.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/inventory")]
[Produces("application/json")]
[Tags("Inventario")]
public class InventoryController(
    GetAllCategoriesUseCase getAllCategoriesUseCase,
    GetCategoryByIdUseCase getCategoryByIdUseCase,
    CreateCategoryUseCase createCategoryUseCase,
    UpdateCategoryUseCase updateCategoryUseCase,
    DeleteCategoryUseCase deleteCategoryUseCase,
    GetAllSuppliersUseCase getAllSuppliersUseCase,
    GetSupplierByIdUseCase getSupplierByIdUseCase,
    CreateSupplierUseCase createSupplierUseCase,
    UpdateSupplierUseCase updateSupplierUseCase,
    DeleteSupplierUseCase deleteSupplierUseCase,
    GetAllReferencesTypesUseCase getAllReferencesTypesUseCase,
    GetReferencesTypeByIdUseCase getReferencesTypeByIdUseCase,
    CreateReferencesTypeUseCase createReferencesTypeUseCase,
    UpdateReferencesTypeUseCase updateReferencesTypeUseCase,
    DeleteReferencesTypeUseCase deleteReferencesTypeUseCase,
    GetAllInventoryMovementsUseCase getAllInventoryMovementsUseCase,
    GetInventoryMovementByIdUseCase getInventoryMovementByIdUseCase,
    GetInventoryMovementsByProductUseCase getInventoryMovementsByProductUseCase,
    CreateInventoryMovementUseCase createInventoryMovementUseCase) : ControllerBase
{
    #region Categories

    [HttpGet("categories")]
    [EndpointSummary("Obtener todas las categorías")]
    [EndpointDescription("Retorna la lista completa de categorías de inventario.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCategories()
    {
        var response = await getAllCategoriesUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("categories/{id:int}")]
    [EndpointSummary("Obtener categoría por ID")]
    [EndpointDescription("Retorna una única categoría de inventario identificada por su ID numérico.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var response = await getCategoryByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPost("categories")]
    [EndpointSummary("Crear una categoría")]
    [EndpointDescription("Crea una nueva categoría de inventario. Retorna 400 si ya existe una categoría con el mismo nombre.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest request)
    {
        var response = await createCategoryUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetCategoryById), new { id = response.CategoryId }, response);
    }

    [HttpPut("categories/{id:int}")]
    [EndpointSummary("Actualizar una categoría")]
    [EndpointDescription("Actualiza el nombre y la descripción de una categoría de inventario existente.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryRequest request)
    {
        var response = await updateCategoryUseCase.ExecuteAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("categories/{id:int}")]
    [EndpointSummary("Eliminar una categoría")]
    [EndpointDescription("Elimina permanentemente una categoría de inventario por ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await deleteCategoryUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Suppliers

    [HttpGet("suppliers")]
    [EndpointSummary("Obtener todos los proveedores")]
    [EndpointDescription("Retorna la lista completa de proveedores registrados.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllSuppliers()
    {
        var response = await getAllSuppliersUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("suppliers/{id:int}")]
    [EndpointSummary("Obtener proveedor por ID")]
    [EndpointDescription("Retorna un único proveedor identificado por su ID numérico.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSupplierById(int id)
    {
        var response = await getSupplierByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPost("suppliers")]
    [EndpointSummary("Crear un proveedor")]
    [EndpointDescription("Crea un nuevo proveedor. Retorna 400 si ya existe un proveedor con el mismo nombre.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateSupplier([FromBody] SupplierRequest request)
    {
        var response = await createSupplierUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetSupplierById), new { id = response.SupplierId }, response);
    }

    [HttpPut("suppliers/{id:int}")]
    [EndpointSummary("Actualizar un proveedor")]
    [EndpointDescription("Actualiza los detalles de contacto y la dirección de un proveedor existente.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierRequest request)
    {
        var response = await updateSupplierUseCase.ExecuteAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("suppliers/{id:int}")]
    [EndpointSummary("Eliminar un proveedor")]
    [EndpointDescription("Elimina permanentemente un proveedor por ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        await deleteSupplierUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region References Types

    [HttpGet("references-types")]
    [EndpointSummary("Obtener todos los tipos de referencia")]
    [EndpointDescription("Retorna la lista completa de tipos de referencia de inventario.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllReferencesTypes()
    {
        var response = await getAllReferencesTypesUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("references-types/{id:int}")]
    [EndpointSummary("Obtener tipo de referencia por ID")]
    [EndpointDescription("Retorna un único tipo de referencia identificado por su ID numérico.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetReferencesTypeById(int id)
    {
        var response = await getReferencesTypeByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPost("references-types")]
    [EndpointSummary("Crear un tipo de referencia")]
    [EndpointDescription("Crea un nuevo tipo de referencia. Retorna 400 si ya existe un tipo de referencia con el mismo nombre.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateReferencesType([FromBody] ReferencesTypeRequest request)
    {
        var response = await createReferencesTypeUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetReferencesTypeById), new { id = response.ReferenceTypeId }, response);
    }

    [HttpPut("references-types/{id:int}")]
    [EndpointSummary("Actualizar un tipo de referencia")]
    [EndpointDescription("Actualiza el nombre y la descripción de un tipo de referencia existente.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateReferencesType(int id, [FromBody] ReferencesTypeRequest request)
    {
        var response = await updateReferencesTypeUseCase.ExecuteAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("references-types/{id:int}")]
    [EndpointSummary("Eliminar un tipo de referencia")]
    [EndpointDescription("Elimina permanentemente un tipo de referencia por ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteReferencesType(int id)
    {
        await deleteReferencesTypeUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Inventory Movements

    [HttpGet("movements")]
    [EndpointSummary("Obtener todos los movimientos de inventario")]
    [EndpointDescription("Retorna la lista completa de movimientos de inventario de todos los productos.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllInventoryMovements()
    {
        var response = await getAllInventoryMovementsUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("movements/{id:int}")]
    [EndpointSummary("Obtener movimiento de inventario por ID")]
    [EndpointDescription("Retorna un único movimiento de inventario identificado por su ID numérico.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetInventoryMovementById(int id)
    {
        var response = await getInventoryMovementByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpGet("movements/by-product/{productId:int}")]
    [EndpointSummary("Obtener movimientos de inventario por producto")]
    [EndpointDescription("Retorna todos los movimientos de inventario asociados con un producto específico.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetInventoryMovementsByProduct(int productId)
    {
        var response = await getInventoryMovementsByProductUseCase.ExecuteAsync(productId);
        return Ok(response);
    }

    [HttpPost("movements")]
    [EndpointSummary("Crear un movimiento de inventario")]
    [EndpointDescription("Registra un nuevo movimiento de inventario (entrada, salida o ajuste) para un producto.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateInventoryMovement([FromBody] InventoryMovementRequest request)
    {
        var response = await createInventoryMovementUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetInventoryMovementById), new { id = response.MovementId }, response);
    }

    #endregion
}
