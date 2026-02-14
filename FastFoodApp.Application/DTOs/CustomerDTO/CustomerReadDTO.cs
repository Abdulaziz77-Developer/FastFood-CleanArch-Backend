namespace FastFoodApp.Application.DTOs.CustomerDTO;

public record CustomerReadDto(
    Guid Id,
    Guid UserId,
    string FullName, // Из сущности User
    string Email,    // Из сущности User
    string Phone,
    string Address,
    string City
);