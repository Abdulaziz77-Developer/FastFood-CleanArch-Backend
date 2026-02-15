using FastFoodApp.Application.DTOs.OrderDTO;

namespace FastFoodApp.Application.Interfaces;

public interface IOrderService
{
    Task<OrderReadDto?> GetOrderByIdAsync(Guid id);
    Task<IEnumerable<OrderReadDto>> GetUserOrdersAsync(Guid userId);
    Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync();
    Task<IEnumerable<OrderReadDto>> GetOrdersByStatusAsync(string status);
    Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto);
    Task<bool> UpdateOrderStatusAsync(Guid orderId, string newStatus);
}
