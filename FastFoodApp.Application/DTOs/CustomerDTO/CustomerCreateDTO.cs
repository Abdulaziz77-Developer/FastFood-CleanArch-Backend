namespace FastFoodApp.Application.DTOs.CustomerDTO;

public record CustomerCreateDto(
    Guid UserId,
    string Phone,
    string Address,
    string City
);