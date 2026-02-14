using FastFoodApp.Application.DTOs.OrderItemDTO;

namespace FastFoodApp.Application.DTOs.OrderDTO;

public record OrderReadDto(
    Guid Id,
    DateTime CreatedAt,
    decimal TotalAmount,
    string Status,
    string DeliveryAddress,
    List<OrderItemReadDto> Items
);