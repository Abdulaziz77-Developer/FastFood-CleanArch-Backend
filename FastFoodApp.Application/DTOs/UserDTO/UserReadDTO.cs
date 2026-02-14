using FastFoodApp.Core.Enums;

namespace FastFoodApp.Application.DTOs.UserDTO;

public record UserReadDto(
    Guid Id,
    string FullName,
    string Email,
    Role Role
);