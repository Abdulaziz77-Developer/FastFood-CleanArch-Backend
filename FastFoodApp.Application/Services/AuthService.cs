using AutoMapper;
using FastFoodApp.Application.DTOs.UserDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Enums;
using FastFoodApp.Core.Interfaces;
using FastFoodApp.Core.Security;
using Google.Apis.Auth;
using System.Text.Json;

namespace FastFoodApp.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly HttpClient _httpClient;

    public AuthService(
        IUnitOfWork unitOfWork, 
        IMapper mapper, 
        ITokenService tokenService,
        IPasswordHasher passwordHasher,
        HttpClient httpClient)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _httpClient = httpClient;
    }

    public async Task<AuthResponseDto?> LoginAsync(UserLoginDto loginDto)
    {
        // Найти пользователя по email
        var user = await _unitOfWork.Auth.GetUserByEmailAsync(loginDto.Email);
        
        if (user == null) return null;
        
        // Проверить пароль
        if (!_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            return null;

        // Генерировать токены
        return CreateAuthResponse(user);
    }

    public async Task<AuthResponseDto?> RegisterAsync(UserRegisterDto registerDto)
    {
        // Проверить существование пользователя
        var existingUser = await _unitOfWork.Auth.GetUserByEmailAsync(registerDto.Email);
        if (existingUser != null) return null;

        // Создать нового пользователя
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = registerDto.Email,
            FullName = registerDto.FullName,
            PasswordHash = _passwordHasher.HashPassword(registerDto.Password),
            Role = Role.Customer,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Auth.CreateUserAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return CreateAuthResponse(user);
    }

    public async Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken)
    {
        // В реальном приложении нужно проверить refresh token в БД
        // Для упрощения просто возвращаем нужные данные
        // TODO: Реализовать сохранение refresh токенов в БД
        return null;
    }

    public async Task<AuthResponseDto?> GoogleLoginAsync(string idToken)
    {
        try
        {
            // Validate Google ID Token using Google.Apis.Auth library
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            
            if (payload == null)
                return null;

            // Check if user exists by email
            var user = await _unitOfWork.Auth.GetUserByEmailAsync(payload.Email);

            if (user == null)
            {
                // Create new user from Google info
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = payload.Email,
                    FullName = payload.Name ?? payload.Email.Split('@')[0],
                    PasswordHash = _passwordHasher.HashPassword(Guid.NewGuid().ToString()),
                    Role = Role.Customer,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.Auth.CreateUserAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }

            return CreateAuthResponse(user);
        }
        catch (InvalidOperationException)
        {
            // Invalid Google token
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        var user = await _unitOfWork.Auth.GetUserByEmailAsync(email);
        return user != null;
    }

    public async Task<UserReadDto?> GetUserByEmailAsync(string email)
    {
        var user = await _unitOfWork.Auth.GetUserByEmailAsync(email);
        if (user == null) return null;

        return _mapper.Map<UserReadDto>(user);
    }

    private AuthResponseDto CreateAuthResponse(User user)
    {
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        return new AuthResponseDto(
            AccessToken: accessToken,
            RefreshToken: refreshToken,
            TokenType: "Bearer",
            ExpiresIn: 3600,
            User: _mapper.Map<UserReadDto>(user)
        );
    }

    public async Task<AuthResponseDto?> FacebookLoginAsync(string accessToken)
    {
        try
        {
            // Get user info from Facebook Graph API
            var facebookUserInfo = await GetFacebookUserInfoAsync(accessToken);
            
            if (facebookUserInfo == null)
                return null;

            // Check if user exists by email
            var user = await _unitOfWork.Auth.GetUserByEmailAsync(facebookUserInfo.Email);

            if (user == null)
            {
                // Create new user from Facebook info
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = facebookUserInfo.Email,
                    FullName = facebookUserInfo.Name ?? facebookUserInfo.Email.Split('@')[0],
                    PasswordHash = _passwordHasher.HashPassword(Guid.NewGuid().ToString()),
                    Role = Role.Customer,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.Auth.CreateUserAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }

            return CreateAuthResponse(user);
        }
        catch
        {
            return null;
        }
    }

    private async Task<FacebookUserInfo?> GetFacebookUserInfoAsync(string accessToken)
    {
        try
        {
            // Call Facebook Graph API to get user info
            var url = $"https://graph.facebook.com/me?fields=id,name,email,picture&access_token={accessToken}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            
            // Parse JSON response
            using var jsonDoc = JsonDocument.Parse(json);
            var root = jsonDoc.RootElement;

            if (!root.TryGetProperty("email", out var emailElement) || emailElement.ValueKind == JsonValueKind.Null)
                return null;

            var email = emailElement.GetString();
            var name = root.TryGetProperty("name", out var nameElement) ? nameElement.GetString() : null;

            if (string.IsNullOrEmpty(email))
                return null;

            return new FacebookUserInfo
            {
                Id = root.TryGetProperty("id", out var idElement) ? idElement.GetString() : string.Empty,
                Name = name ?? string.Empty,
                Email = email
            };
        }
        catch
        {
            return null;
        }
    }
}

/// <summary>
/// Helper class for Facebook user information
/// </summary>
public class FacebookUserInfo
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
