using FastFoodApp.Application.DTOs.OrderItemDTO;

namespace FastFoodApp.Application.DTOs.OrderDTO;

public record OrderCreateDto(
    Guid UserId,
    string DeliveryAddress,
    string PaymentMethod,
    decimal TotalPrice,
    List<OrderItemCreateDto> Items
);