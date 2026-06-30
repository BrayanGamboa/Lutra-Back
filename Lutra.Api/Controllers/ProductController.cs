using Lutra.Application.Products.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lutra.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/products")]
[Produces("application/json")]
[Tags("Productos")]
public class ProductController(
    GetAllProductsUseCase getAllProductsUseCase,
    GetProductByIdUseCase getProductByIdUseCase,
    GetProductsByCategoryUseCase getProductsByCategoryUseCase,
    GetProductsBySupplierUseCase getProductsBySupplierUseCase,
    CreateProductUseCase createProductUseCase,
    UpdateProductUseCase updateProductUseCase,
    DeleteProductUseCase deleteProductUseCase) : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Obtener todos los productos")]
    [EndpointDescription("Retorna la lista completa de productos en el catálogo.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await getAllProductsUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    [EndpointSummary("Obtener producto por ID")]
    [EndpointDescription("Retorna un único producto identificado por su ID numérico.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductById(int id)
    {
        var response = await getProductByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpGet("by-category/{categoryId:int}")]
    [EndpointSummary("Obtener productos por categoría")]
    [EndpointDescription("Retorna todos los productos pertenecientes a la categoría especificada.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductsByCategory(int categoryId)
    {
        var response = await getProductsByCategoryUseCase.ExecuteAsync(categoryId);
        return Ok(response);
    }

    [HttpGet("by-supplier/{supplierId:int}")]
    [EndpointSummary("Obtener productos por proveedor")]
    [EndpointDescription("Retorna todos los productos provenientes del proveedor especificado.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductsBySupplier(int supplierId)
    {
        var response = await getProductsBySupplierUseCase.ExecuteAsync(supplierId);
        return Ok(response);
    }

    [HttpPost]
    [EndpointSummary("Crear un producto")]
    [EndpointDescription("Crea un nuevo producto en el catálogo. Retorna 400 si ya existe un producto con el mismo SKU.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
    {
        var response = await createProductUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetProductById), new { id = response.ProductId }, response);
    }

    [HttpPut("{id:int}")]
    [EndpointSummary("Actualizar un producto")]
    [EndpointDescription("Actualiza los detalles de un producto existente, incluyendo precio, costo, proveedor y categoría.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequest request)
    {
        var response = await updateProductUseCase.ExecuteAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Eliminar un producto")]
    [EndpointDescription("Elimina permanentemente un producto por ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await deleteProductUseCase.ExecuteAsync(id);
        return NoContent();
    }
}
