namespace FastFoodApp.Application.DTOs.OrderItemDTO;

public record OrderItemCreateDto(
    Guid FoodId,
    int Quantity,
    decimal PricePerUnit
);