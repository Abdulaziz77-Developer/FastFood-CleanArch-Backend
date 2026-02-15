using FastFoodApp.Application.DTOs.UserDTO;

namespace FastFoodApp.Application.Interfaces;

public interface IAuthService
{
    // Basic Auth
    Task<AuthResponseDto?> LoginAsync(UserLoginDto loginDto);
    Task<AuthResponseDto?> RegisterAsync(UserRegisterDto registerDto);
    
    // Token Management
    Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken);
    
    // OAuth
    Task<AuthResponseDto?> GoogleLoginAsync(string idToken);
    Task<AuthResponseDto?> FacebookLoginAsync(string accessToken);
    
    // User Check
    Task<bool> UserExistsAsync(string email);
    Task<UserReadDto?> GetUserByEmailAsync(string email);
}
