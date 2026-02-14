namespace FastFoodApp.Application.DTOs.UserDTO;

public record UserLoginDto(
    string Email,
    string Password
);