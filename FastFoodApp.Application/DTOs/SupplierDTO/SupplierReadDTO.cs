namespace FastFoodApp.Application.DTOs.SupplierDTO;

public record SupplierReadDto(
    Guid Id,
    Guid UserId,
    string RestaurantName,
    string ImageUrl,
    string City
);