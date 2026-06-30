using Lutra.Application.Catalog.UseCases.City;
using Lutra.Application.Catalog.UseCases.Country;
using Lutra.Application.Catalog.UseCases.Department;
using Lutra.Application.Catalog.UseCases.DocumentType;
using Lutra.Application.Catalog.UseCases.MethodPayment;
using Lutra.Application.Catalog.UseCases.TaxRegime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lutra.Api.Controllers;

/// <summary>
/// Manages catalog reference data: countries, departments, cities, document types, payment methods, and tax regimes.
/// </summary>
[ApiController]
[Authorize]
[Tags("Catálogo - Configuración")]
[Route("api/catalog")]
[Produces("application/json")]
public class CatalogController : ControllerBase
{
    private readonly GetAllCountriesUseCase _getAllCountriesUseCase;
    private readonly GetCountryByIdUseCase _getCountryByIdUseCase;
    private readonly CreateCountryUseCase _createCountryUseCase;
    private readonly UpdateCountryUseCase _updateCountryUseCase;
    private readonly DeleteCountryUseCase _deleteCountryUseCase;

    private readonly GetAllDepartmentsUseCase _getAllDepartmentsUseCase;
    private readonly GetDepartmentByIdUseCase _getDepartmentByIdUseCase;
    private readonly GetDepartmentsByCountryUseCase _getDepartmentsByCountryUseCase;
    private readonly CreateDepartmentUseCase _createDepartmentUseCase;
    private readonly UpdateDepartmentUseCase _updateDepartmentUseCase;
    private readonly DeleteDepartmentUseCase _deleteDepartmentUseCase;

    private readonly GetAllCitiesUseCase _getAllCitiesUseCase;
    private readonly GetCityByIdUseCase _getCityByIdUseCase;
    private readonly GetCitiesByDepartmentUseCase _getCitiesByDepartmentUseCase;
    private readonly CreateCityUseCase _createCityUseCase;
    private readonly UpdateCityUseCase _updateCityUseCase;
    private readonly DeleteCityUseCase _deleteCityUseCase;

    private readonly GetAllDocumentTypesUseCase _getAllDocumentTypesUseCase;
    private readonly GetDocumentTypeByIdUseCase _getDocumentTypeByIdUseCase;
    private readonly CreateDocumentTypeUseCase _createDocumentTypeUseCase;
    private readonly UpdateDocumentTypeUseCase _updateDocumentTypeUseCase;
    private readonly DeleteDocumentTypeUseCase _deleteDocumentTypeUseCase;

    private readonly GetAllMethodPaymentsUseCase _getAllMethodPaymentsUseCase;
    private readonly GetMethodPaymentByIdUseCase _getMethodPaymentByIdUseCase;
    private readonly CreateMethodPaymentUseCase _createMethodPaymentUseCase;
    private readonly UpdateMethodPaymentUseCase _updateMethodPaymentUseCase;
    private readonly DeleteMethodPaymentUseCase _deleteMethodPaymentUseCase;

    private readonly GetAllTaxRegimesUseCase _getAllTaxRegimesUseCase;
    private readonly GetTaxRegimeByIdUseCase _getTaxRegimeByIdUseCase;
    private readonly CreateTaxRegimeUseCase _createTaxRegimeUseCase;
    private readonly UpdateTaxRegimeUseCase _updateTaxRegimeUseCase;
    private readonly DeleteTaxRegimeUseCase _deleteTaxRegimeUseCase;

    public CatalogController(
        GetAllCountriesUseCase getAllCountriesUseCase,
        GetCountryByIdUseCase getCountryByIdUseCase,
        CreateCountryUseCase createCountryUseCase,
        UpdateCountryUseCase updateCountryUseCase,
        DeleteCountryUseCase deleteCountryUseCase,
        GetAllDepartmentsUseCase getAllDepartmentsUseCase,
        GetDepartmentByIdUseCase getDepartmentByIdUseCase,
        GetDepartmentsByCountryUseCase getDepartmentsByCountryUseCase,
        CreateDepartmentUseCase createDepartmentUseCase,
        UpdateDepartmentUseCase updateDepartmentUseCase,
        DeleteDepartmentUseCase deleteDepartmentUseCase,
        GetAllCitiesUseCase getAllCitiesUseCase,
        GetCityByIdUseCase getCityByIdUseCase,
        GetCitiesByDepartmentUseCase getCitiesByDepartmentUseCase,
        CreateCityUseCase createCityUseCase,
        UpdateCityUseCase updateCityUseCase,
        DeleteCityUseCase deleteCityUseCase,
        GetAllDocumentTypesUseCase getAllDocumentTypesUseCase,
        GetDocumentTypeByIdUseCase getDocumentTypeByIdUseCase,
        CreateDocumentTypeUseCase createDocumentTypeUseCase,
        UpdateDocumentTypeUseCase updateDocumentTypeUseCase,
        DeleteDocumentTypeUseCase deleteDocumentTypeUseCase,
        GetAllMethodPaymentsUseCase getAllMethodPaymentsUseCase,
        GetMethodPaymentByIdUseCase getMethodPaymentByIdUseCase,
        CreateMethodPaymentUseCase createMethodPaymentUseCase,
        UpdateMethodPaymentUseCase updateMethodPaymentUseCase,
        DeleteMethodPaymentUseCase deleteMethodPaymentUseCase,
        GetAllTaxRegimesUseCase getAllTaxRegimesUseCase,
        GetTaxRegimeByIdUseCase getTaxRegimeByIdUseCase,
        CreateTaxRegimeUseCase createTaxRegimeUseCase,
        UpdateTaxRegimeUseCase updateTaxRegimeUseCase,
        DeleteTaxRegimeUseCase deleteTaxRegimeUseCase)
    {
        _getAllCountriesUseCase = getAllCountriesUseCase;
        _getCountryByIdUseCase = getCountryByIdUseCase;
        _createCountryUseCase = createCountryUseCase;
        _updateCountryUseCase = updateCountryUseCase;
        _deleteCountryUseCase = deleteCountryUseCase;

        _getAllDepartmentsUseCase = getAllDepartmentsUseCase;
        _getDepartmentByIdUseCase = getDepartmentByIdUseCase;
        _getDepartmentsByCountryUseCase = getDepartmentsByCountryUseCase;
        _createDepartmentUseCase = createDepartmentUseCase;
        _updateDepartmentUseCase = updateDepartmentUseCase;
        _deleteDepartmentUseCase = deleteDepartmentUseCase;

        _getAllCitiesUseCase = getAllCitiesUseCase;
        _getCityByIdUseCase = getCityByIdUseCase;
        _getCitiesByDepartmentUseCase = getCitiesByDepartmentUseCase;
        _createCityUseCase = createCityUseCase;
        _updateCityUseCase = updateCityUseCase;
        _deleteCityUseCase = deleteCityUseCase;

        _getAllDocumentTypesUseCase = getAllDocumentTypesUseCase;
        _getDocumentTypeByIdUseCase = getDocumentTypeByIdUseCase;
        _createDocumentTypeUseCase = createDocumentTypeUseCase;
        _updateDocumentTypeUseCase = updateDocumentTypeUseCase;
        _deleteDocumentTypeUseCase = deleteDocumentTypeUseCase;

        _getAllMethodPaymentsUseCase = getAllMethodPaymentsUseCase;
        _getMethodPaymentByIdUseCase = getMethodPaymentByIdUseCase;
        _createMethodPaymentUseCase = createMethodPaymentUseCase;
        _updateMethodPaymentUseCase = updateMethodPaymentUseCase;
        _deleteMethodPaymentUseCase = deleteMethodPaymentUseCase;

        _getAllTaxRegimesUseCase = getAllTaxRegimesUseCase;
        _getTaxRegimeByIdUseCase = getTaxRegimeByIdUseCase;
        _createTaxRegimeUseCase = createTaxRegimeUseCase;
        _updateTaxRegimeUseCase = updateTaxRegimeUseCase;
        _deleteTaxRegimeUseCase = deleteTaxRegimeUseCase;
    }

    #region Countries

    /// <summary>Retorna todos los paises.</summary>
    [HttpGet("countries")]
    [SwaggerOperation(Summary = "Retorna todos los paises", Description = "Retorna una lista completa con los paises registrados.")]
    [ProducesResponseType(typeof(IEnumerable<CountryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCountries()
    {
        var result = await _getAllCountriesUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>Retorna un pais por su ID.</summary>
    [HttpGet("countries/{id:int}")]
    [SwaggerOperation(Summary = "Retorna un pais por su ID", Description = "Retorna un pais que coincide con el ID.")]
    [ProducesResponseType(typeof(CountryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCountryById(int id)
    {
        var result = await _getCountryByIdUseCase.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>Crea un nuevo pais.</summary>
    [HttpPost("countries")]
    [SwaggerOperation(Summary = "Crea un pais", Description = "Registra un nuevo pais.")]
    [ProducesResponseType(typeof(CountryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCountry([FromBody] CountryRequest request)
    {
        var result = await _createCountryUseCase.ExecuteAsync(request);
        return Ok(result);
    }

    /// <summary>Actualiza un pais existente.</summary>
    [HttpPut("countries/{id:int}")]
    [SwaggerOperation(Summary = "Actualiza un pais", Description = "Actualiza el nombre del pais identificado por el ID proporcionado.")]
    [ProducesResponseType(typeof(CountryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryRequest request)
    {
        var result = await _updateCountryUseCase.ExecuteAsync(id, request);
        return Ok(result);
    }

    /// <summary>Elimina un pais.</summary>
    [HttpDelete("countries/{id:int}")]
    [SwaggerOperation(Summary = "Elimina un pais", Description = "Elimina permanentemente el pais identificado por el ID proporcionado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        await _deleteCountryUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Departments

    /// <summary>Retorna todos los departamentos.</summary>
    [HttpGet("departments")]
    [SwaggerOperation(Summary = "Retorna todos los departamentos", Description = "Retorna la lista completa de departamentos registrados.")]
    [ProducesResponseType(typeof(IEnumerable<DepartmentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllDepartments()
    {
        var result = await _getAllDepartmentsUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>Retorna un departamento por su ID.</summary>
    [HttpGet("departments/{id:int}")]
    [SwaggerOperation(Summary = "Retorna un departamento por ID", Description = "Retorna un solo departamento que coincide con el ID.")]
    [ProducesResponseType(typeof(DepartmentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var result = await _getDepartmentByIdUseCase.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>Retorna todos los departamentos pertenecientes a un pais.</summary>
    [HttpGet("departments/by-country/{countryId:int}")]
    [SwaggerOperation(Summary = "Retorna departamentos por pais", Description = "Filtra los departamentos por el identificador del pais proporcionado.")]
    [ProducesResponseType(typeof(IEnumerable<DepartmentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDepartmentsByCountry(int countryId)
    {
        var result = await _getDepartmentsByCountryUseCase.ExecuteAsync(countryId);
        return Ok(result);
    }

    /// <summary>Retorna un nuevo departamento.</summary>
    [HttpPost("departments")]
    [SwaggerOperation(Summary = "Crea un departamento", Description = "Registra un nuevo departamento vinculado a un pais existente.")]
    [ProducesResponseType(typeof(DepartmentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateDepartment([FromBody] DepartmentRequest request)
    {
        var result = await _createDepartmentUseCase.ExecuteAsync(request);
        return Ok(result);
    }

    /// <summary>Actualiza un departamento existente.</summary>
    [HttpPut("departments/{id:int}")]
    [SwaggerOperation(Summary = "Actualiza un departamento", Description = "Sobrescribe el nombre y la asociación de país del departamento identificado por el ID proporcionado.")]
    [ProducesResponseType(typeof(DepartmentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentRequest request)
    {
        var result = await _updateDepartmentUseCase.ExecuteAsync(id, request);
        return Ok(result);
    }

    /// <summary>Elimina un departamento.</summary>
    [HttpDelete("departments/{id:int}")]
    [SwaggerOperation(Summary = "Elimina un departamento", Description = "Elimina permanentemente el departamento identificado por el ID proporcionado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        await _deleteDepartmentUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Cities

    /// <summary>Retorna todas las ciudades.</summary>
    [HttpGet("cities")]
    [SwaggerOperation(Summary = "Retorna todas las ciudades", Description = "Retorna la lista completa de ciudades registradas.")]
    [ProducesResponseType(typeof(IEnumerable<CityResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCities()
    {
        var result = await _getAllCitiesUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>Retorna una ciudad por su ID.</summary>
    [HttpGet("cities/{id:int}")]
    [SwaggerOperation(Summary = "Retorna una ciudad por su ID", Description = "Retorna una sola ciudad que coincide con el identificador proporcionado.")]
    [ProducesResponseType(typeof(CityResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCityById(int id)
    {
        var result = await _getCityByIdUseCase.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>Retorna todas las ciudades pertenecientes a un departamento.</summary>
    [HttpGet("cities/by-department/{deptId:int}")]
    [SwaggerOperation(Summary = "Retorna ciudades por departamento", Description = "Filtra las ciudades por el identificador del departamento proporcionado.")]
    [ProducesResponseType(typeof(IEnumerable<CityResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCitiesByDepartment(int deptId)
    {
        var result = await _getCitiesByDepartmentUseCase.ExecuteAsync(deptId);
        return Ok(result);
    }

    /// <summary>Registra una nueva ciudad.</summary>
    [HttpPost("cities")]
    [SwaggerOperation(Summary = "Crea una ciudad", Description = "Registra una nueva ciudad vinculada a un departamento existente.")]
    [ProducesResponseType(typeof(CityResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCity([FromBody] CityRequest request)
    {
        var result = await _createCityUseCase.ExecuteAsync(request);
        return Ok(result);
    }

    /// <summary>Actualiza una ciudad existente.</summary>
    [HttpPut("cities/{id:int}")]
    [SwaggerOperation(Summary = "Actualiza una ciudad", Description = "Sobrescribe el nombre y la asociación del departamento de la ciudad identificada por el ID proporcionado.")]
    [ProducesResponseType(typeof(CityResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCity(int id, [FromBody] CityRequest request)
    {
        var result = await _updateCityUseCase.ExecuteAsync(id, request);
        return Ok(result);
    }

    /// <summary>Elimina una ciudad.</summary>
    [HttpDelete("cities/{id:int}")]
    [SwaggerOperation(Summary = "Elimina una ciudad", Description = "Elimina permanentemente la ciudad identificada por el ID proporcionado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCity(int id)
    {
        await _deleteCityUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Document Types

    /// <summary>Retorna todos los tipos de documentos.</summary>
    [HttpGet("document-types")]
    [SwaggerOperation(Summary = "Retorna todos los tipos de documentos", Description = "Retorna la lista completa de tipos de documentos registrados (por ejemplo, CC, NIT, Pasaporte).")]
    [ProducesResponseType(typeof(IEnumerable<DocumentTypeResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllDocumentTypes()
    {
        var result = await _getAllDocumentTypesUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>Retorna un tipo de documento por su identificador.</summary>
    [HttpGet("document-types/{id:int}")]
    [SwaggerOperation(Summary = "Retorna un tipo de documento por ID", Description = "Retorna un único tipo de documento que coincide con el identificador proporcionado.")]
    [ProducesResponseType(typeof(DocumentTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDocumentTypeById(int id)
    {
        var result = await _getDocumentTypeByIdUseCase.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>Crea un nuevo tipo de documento.</summary>
    [HttpPost("document-types")]
    [SwaggerOperation(Summary = "Crea un tipo de documento", Description = "Registra un nuevo tipo de documento en el catálogo.")]
    [ProducesResponseType(typeof(DocumentTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateDocumentType([FromBody] DocumentTypeRequest request)
    {
        var result = await _createDocumentTypeUseCase.ExecuteAsync(request);
        return Ok(result);
    }

    /// <summary>Actualiza un tipo de documento existente.</summary>
    [HttpPut("document-types/{id:int}")]
    [SwaggerOperation(Summary = "Actualiza un tipo de documento", Description = "Sobrescribe el nombre del tipo de documento identificado por el ID proporcionado.")]
    [ProducesResponseType(typeof(DocumentTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateDocumentType(int id, [FromBody] DocumentTypeRequest request)
    {
        var result = await _updateDocumentTypeUseCase.ExecuteAsync(id, request);
        return Ok(result);
    }

    /// <summary>Elimina un tipo de documento.</summary>
    [HttpDelete("document-types/{id:int}")]
    [SwaggerOperation(Summary = "Elimina un tipo de documento", Description = "Elimina permanentemente el tipo de documento identificado por el ID proporcionado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteDocumentType(int id)
    {
        await _deleteDocumentTypeUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Payment Methods

    /// <summary>Retorna todos los métodos de pago.</summary>
    [HttpGet("payment-methods")]
    [SwaggerOperation(Summary = "Retorna todos los métodos de pago", Description = "Retorna la lista completa de métodos de pago registrados.")]
    [ProducesResponseType(typeof(IEnumerable<MethodPaymentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllMethodPayments()
    {
        var result = await _getAllMethodPaymentsUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>Retorna un método de pago por su identificador.</summary>
    [HttpGet("payment-methods/{id:int}")]
    [SwaggerOperation(Summary = "Retorna un método de pago por ID", Description = "Retorna un único método de pago que coincide con el identificador proporcionado.")]
    [ProducesResponseType(typeof(MethodPaymentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMethodPaymentById(int id)
    {
        var result = await _getMethodPaymentByIdUseCase.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>Crea un nuevo método de pago.</summary>
    [HttpPost("payment-methods")]
    [SwaggerOperation(Summary = "Crea un método de pago", Description = "Registra un nuevo método de pago en el catálogo.")]
    [ProducesResponseType(typeof(MethodPaymentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateMethodPayment([FromBody] MethodPaymentRequest request)
    {
        var result = await _createMethodPaymentUseCase.ExecuteAsync(request);
        return Ok(result);
    }

    /// <summary>Actualiza un método de pago existente.</summary>
    [HttpPut("payment-methods/{id:int}")]
    [SwaggerOperation(Summary = "Actualiza un método de pago", Description = "Sobrescribe el nombre del método de pago identificado por el ID proporcionado.")]
    [ProducesResponseType(typeof(MethodPaymentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateMethodPayment(int id, [FromBody] MethodPaymentRequest request)
    {
        var result = await _updateMethodPaymentUseCase.ExecuteAsync(id, request);
        return Ok(result);
    }

    /// <summary>Elimina un método de pago.</summary>
    [HttpDelete("payment-methods/{id:int}")]
    [SwaggerOperation(Summary = "Elimina un método de pago", Description = "Elimina permanentemente el método de pago identificado por el ID proporcionado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteMethodPayment(int id)
    {
        await _deleteMethodPaymentUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion

    #region Tax Regimes

    /// <summary>Retorna todos los regímenes fiscales.</summary>
    [HttpGet("tax-regimes")]
    [SwaggerOperation(Summary = "Retorna todos los regímenes fiscales", Description = "Retorna la lista completa de regímenes fiscales registrados.")]
    [ProducesResponseType(typeof(IEnumerable<TaxRegimeResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllTaxRegimes()
    {
        var result = await _getAllTaxRegimesUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>Retorna un régimen fiscal por su identificador.</summary>
    [HttpGet("tax-regimes/{id:int}")]
    [SwaggerOperation(Summary = "Retorna un régimen fiscal por ID", Description = "Retorna un único régimen fiscal que coincide con el identificador proporcionado.")]
    [ProducesResponseType(typeof(TaxRegimeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTaxRegimeById(int id)
    {
        var result = await _getTaxRegimeByIdUseCase.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>Crea un nuevo régimen fiscal.</summary>
    [HttpPost("tax-regimes")]
    [SwaggerOperation(Summary = "Crea un régimen fiscal", Description = "Registra un nuevo régimen fiscal en el catálogo.")]
    [ProducesResponseType(typeof(TaxRegimeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateTaxRegime([FromBody] TaxRegimeRequest request)
    {
        var result = await _createTaxRegimeUseCase.ExecuteAsync(request);
        return Ok(result);
    }

    /// <summary>Actualiza un régimen fiscal existente.</summary>
    [HttpPut("tax-regimes/{id:int}")]
    [SwaggerOperation(Summary = "Actualiza un régimen fiscal", Description = "Sobrescribe el nombre y la descripción del régimen fiscal identificado por el ID proporcionado.")]
    [ProducesResponseType(typeof(TaxRegimeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateTaxRegime(int id, [FromBody] TaxRegimeRequest request)
    {
        var result = await _updateTaxRegimeUseCase.ExecuteAsync(id, request);
        return Ok(result);
    }

    /// <summary>Elimina un régimen fiscal.</summary>
    [HttpDelete("tax-regimes/{id:int}")]
    [SwaggerOperation(Summary = "Elimina un régimen fiscal", Description = "Elimina permanentemente el régimen fiscal identificado por el ID proporcionado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteTaxRegime(int id)
    {
        await _deleteTaxRegimeUseCase.ExecuteAsync(id);
        return NoContent();
    }

    #endregion
}
