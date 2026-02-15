using FastFoodApp.Application.DTOs.UserDTO;
using FastFoodApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Проверить существует ли пользователь
        var userExists = await _authService.UserExistsAsync(registerDto.Email);
        if (userExists)
            return BadRequest(new { message = "User with this email already exists" });

        var result = await _authService.RegisterAsync(registerDto);
        if (result == null)
            return BadRequest(new { message = "Registration failed" });

        return Ok(new
        {
            message = "User registered successfully",
            data = result
        });
    }

    /// <summary>
    /// Логин пользователя с email и паролем
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.LoginAsync(loginDto);
        if (result == null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(new
        {
            message = "Login successful",
            data = result
        });
    }

    /// <summary>
    /// Логин через Google OAuth
    /// </summary>
    [HttpPost("google")]
    [AllowAnonymous]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        if (string.IsNullOrEmpty(request.IdToken))
            return BadRequest(new { message = "IdToken is required" });

        var result = await _authService.GoogleLoginAsync(request.IdToken);
        if (result == null)
            return Unauthorized(new { message = "Google login failed" });

        return Ok(new
        {
            message = "Google login successful",
            data = result
        });
    }

    /// <summary>
    /// Логин через Facebook OAuth
    /// </summary>
    [HttpPost("facebook")]
    [AllowAnonymous]
    public async Task<IActionResult> FacebookLogin([FromBody] FacebookLoginRequest request)
    {
        if (string.IsNullOrEmpty(request.AccessToken))
            return BadRequest(new { message = "AccessToken is required" });

        var result = await _authService.FacebookLoginAsync(request.AccessToken);
        if (result == null)
            return Unauthorized(new { message = "Facebook login failed" });

        return Ok(new
        {
            message = "Facebook login successful",
            data = result
        });
    }

    /// <summary>
    /// Обновить access token используя refresh token
    /// </summary>
    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        if (string.IsNullOrEmpty(refreshTokenDto.RefreshToken))
            return BadRequest(new { message = "RefreshToken is required" });

        var result = await _authService.RefreshTokenAsync(refreshTokenDto.RefreshToken);
        if (result == null)
            return Unauthorized(new { message = "Invalid refresh token" });

        return Ok(new
        {
            message = "Token refreshed successfully",
            data = result
        });
    }

    /// <summary>
    /// Получить данные текущего пользователя
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var emailClaim = User.FindFirst("email");
        if (emailClaim == null)
            return Unauthorized(new { message = "Email claim not found" });

        var user = await _authService.GetUserByEmailAsync(emailClaim.Value);
        if (user == null)
            return NotFound(new { message = "User not found" });

        return Ok(new
        {
            message = "User data retrieved successfully",
            data = user
        });
    }
}

public record GoogleLoginRequest(string IdToken);
public record FacebookLoginRequest(string AccessToken);
