namespace FastFoodApp.Application.DTOs.FoodDTO;

public record FoodReadDto(
    Guid Id, 
    string Name, 
    string Description, 
    decimal Price, 
    string? ImageUrl, 
    bool IsAvailable,
    Guid CategoryId,
    string CategoryName, // Для отображения текста "Burgers"
    Guid SupplierId,
    string SupplierName   // Для отображения текста "Burger King"
);