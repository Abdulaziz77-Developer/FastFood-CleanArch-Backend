namespace FastFoodApp.Application.DTOs.UserDTO;

public record AuthResponseDto(
    string AccessToken,
    string RefreshToken,
    string TokenType,
    int ExpiresIn,
    UserReadDto User
);

public record RefreshTokenDto(
    string RefreshToken
);
