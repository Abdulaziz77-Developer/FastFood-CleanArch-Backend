namespace FastFoodApp.Application.DTOs.CustomerDTO;

public record CustomerUpdateDto(
    string Phone,
    string Address,
    string City
);