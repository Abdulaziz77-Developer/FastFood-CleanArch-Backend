namespace FastFoodApp.Application.DTOs.Food;

public record FoodUpdateDto(
    string Name, 
    string Description, 
    decimal Price, 
    string? ImageUrl, 
    bool IsAvailable,
    Guid CategoryId // Если вдруг решили сменить категорию
);  