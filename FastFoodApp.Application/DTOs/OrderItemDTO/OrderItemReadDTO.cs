namespace FastFoodApp.Application.DTOs.OrderItemDTO;

public record OrderItemReadDto(
    Guid Id,
    Guid FoodId,
    string FoodName,    // Подтянем из сущности Food
    string? FoodImageUrl, // Чтобы в истории заказов были картинки
    int Quantity,
    decimal Price,      // Цена, зафиксированная в момент покупки
    decimal SubTotal    // Рассчитаем как Price * Quantity
);