using FastFoodApp.Application.DTOs.OrderItemDTO;

namespace FastFoodApp.Application.DTOs.OrderDTO;

public record OrderCreateDto(
    string DeliveryAddress,
    List<OrderItemCreateDto> Items
);