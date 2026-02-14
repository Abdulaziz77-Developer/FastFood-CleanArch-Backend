namespace FastFoodApp.Application.DTOs.FoodDTO;

public record FoodCreateDto(
    string Name, 
    string Description, 
    decimal Price, 
    string? ImageUrl, 
    Guid CategoryId, 
    Guid SupplierId
);