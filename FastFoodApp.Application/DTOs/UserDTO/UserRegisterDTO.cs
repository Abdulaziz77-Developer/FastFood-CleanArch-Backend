using System.ComponentModel.DataAnnotations;

namespace FastFoodApp.Application.DTOs.UserDTO;

public record UserRegisterDto(
    [Required] string FullName,
    [Required, EmailAddress] string Email,
    [Required, MinLength(6)] string Password
);