using FastFoodApp.Application.DTOs.SupplierDTO;
using FastFoodApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    /// <summary>
    /// Получить всех поставщиков
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(new
            {
                message = "Suppliers retrieved successfully",
                data = suppliers
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить поставщика по ID
    /// </summary>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound(new { message = "Supplier not found" });

            return Ok(new
            {
                message = "Supplier retrieved successfully",
                data = supplier
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить поставщика по ID пользователя
    /// </summary>
    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        try
        {
            var supplier = await _supplierService.GetSupplierByUserIdAsync(userId);
            if (supplier == null)
                return NotFound(new { message = "Supplier not found" });

            return Ok(new
            {
                message = "Supplier retrieved successfully",
                data = supplier
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить поставщиков по городу
    /// </summary>
    [HttpGet("city/{city}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByCity(string city)
    {
        try
        {
            var suppliers = await _supplierService.GetSuppliersByCityAsync(city);
            return Ok(new
            {
                message = "Suppliers retrieved successfully",
                data = suppliers
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Создать нового поставщика
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] SupplierCreateDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var supplier = await _supplierService.CreateSupplierAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, new
            {
                message = "Supplier created successfully",
                data = supplier
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Обновить поставщика
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Supplier")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SupplierUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var success = await _supplierService.UpdateSupplierAsync(id, updateDto);
            if (!success)
                return NotFound(new { message = "Supplier not found" });

            return Ok(new { message = "Supplier updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
