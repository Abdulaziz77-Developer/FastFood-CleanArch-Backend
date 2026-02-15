using FastFoodApp.Application.DTOs.OrderDTO;
using FastFoodApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Получить все заказы (только для админов)
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(new
            {
                message = "Orders retrieved successfully",
                data = orders
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить заказ по ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(new
            {
                message = "Order retrieved successfully",
                data = order
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить заказы текущего пользователя
    /// </summary>
    [HttpGet("my-orders")]
    public async Task<IActionResult> GetMyOrders()
    {
        try
        {
            var userIdClaim = User.FindFirst("sub") ?? User.FindFirst("nameid");
            if (userIdClaim == null)
                return Unauthorized(new { message = "User ID not found in token" });

            if (!Guid.TryParse(userIdClaim.Value, out var userId))
                return BadRequest(new { message = "Invalid user ID format" });

            var orders = await _orderService.GetUserOrdersAsync(userId);
            return Ok(new
            {
                message = "User orders retrieved successfully",
                data = orders
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить заказы по статусу
    /// </summary>
    [HttpGet("status/{status}")]
    [Authorize(Roles = "Admin,Courier")]
    public async Task<IActionResult> GetByStatus(string status)
    {
        try
        {
            var orders = await _orderService.GetOrdersByStatusAsync(status);
            return Ok(new
            {
                message = "Orders retrieved successfully",
                data = orders
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderCreateDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var order = await _orderService.CreateOrderAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, new
            {
                message = "Order created successfully",
                data = order
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Обновить статус заказа
    /// </summary>
    [HttpPatch("{id}/status")]
    [Authorize(Roles = "Admin,Courier")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusRequest request)
    {
        if (string.IsNullOrEmpty(request.Status))
            return BadRequest(new { message = "Status is required" });

        try
        {
            var success = await _orderService.UpdateOrderStatusAsync(id, request.Status);
            if (!success)
                return NotFound(new { message = "Order not found" });

            return Ok(new { message = "Order status updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}

public record UpdateOrderStatusRequest(string Status);
