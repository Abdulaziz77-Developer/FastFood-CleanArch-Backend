namespace FastFoodApp.Application.DTOs.CategoryDTO;

public record CategoryReadDto(
    Guid Id, 
    string Name
    // Сюда можно добавить string? ImageUrl, если решишь добавить иконку в модель позже
);