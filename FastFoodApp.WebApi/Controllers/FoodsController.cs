using FastFoodApp.Application.DTOs.FoodDTO;
using FastFoodApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodsController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    /// <summary>
    /// Получить все продукты
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return Ok(new
            {
                message = "Foods retrieved successfully",
                data = foods
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить продукт по ID
    /// </summary>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null)
                return NotFound(new { message = "Food not found" });

            return Ok(new
            {
                message = "Food retrieved successfully",
                data = food
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить продукты по категории
    /// </summary>
    [HttpGet("category/{categoryId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByCategory(Guid categoryId)
    {
        try
        {
            var foods = await _foodService.GetFoodsByCategoryAsync(categoryId);
            return Ok(new
            {
                message = "Foods retrieved successfully",
                data = foods
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Создать новый продукт (требует авторизацию)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Admin,Supplier")]
    public async Task<IActionResult> Create([FromBody] FoodCreateDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var food = await _foodService.CreateFoodAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = food.Id }, new
            {
                message = "Food created successfully",
                data = food
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Обновить продукт
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Supplier")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FoodUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var success = await _foodService.UpdateFoodAsync(id, updateDto);
            if (!success)
                return NotFound(new { message = "Food not found" });

            return Ok(new { message = "Food updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Удалить продукт
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Supplier")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var success = await _foodService.DeleteFoodAsync(id);
            if (!success)
                return NotFound(new { message = "Food not found" });

            return Ok(new { message = "Food deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
