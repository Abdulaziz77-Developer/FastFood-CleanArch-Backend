using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetUserOrdersAsync(Guid userId);
    Task<IEnumerable<Order>> GetAllOrdersAsync(); // Для админа
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status); // Для курьера
    Task AddAsync(Order order);
    Task UpdateStatusAsync(Guid orderId, string newStatus);
}