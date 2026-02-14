namespace FastFoodApp.Application.DTOs.SupplierDTO;

public record SupplierUpdateDto(
    string RestaurantName,
    string ImageUrl,
    string City
);