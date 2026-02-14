namespace FastFoodApp.Application.DTOs.SupplierDTO;

public record SupplierCreateDto(
    Guid UserId,
    string RestaurantName,
    string ImageUrl,
    string City
);