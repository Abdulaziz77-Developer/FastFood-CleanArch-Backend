using FastFoodApp.Application.DTOs.UserDTO;
using FastFoodApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UsersController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    /// <summary>
    /// Получить пользователя по ID
    /// </summary>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(new
            {
                message = "User retrieved successfully",
                data = user
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить пользователя по email
    /// </summary>
    [HttpGet("by-email/{email}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return BadRequest(new { message = "Email is required" });

        try
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(new
            {
                message = "User retrieved successfully",
                data = user
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Получить данные текущего пользователя
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        try
        {
            var userIdClaim = User.FindFirst("nameid") ?? User.FindFirst("sub");
            if (userIdClaim == null)
                return Unauthorized(new { message = "User ID not found in token" });

            if (!Guid.TryParse(userIdClaim.Value, out var userId))
                return BadRequest(new { message = "Invalid user ID format" });

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(new
            {
                message = "Current user retrieved successfully",
                data = user
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Проверить существует ли пользователь с таким email
    /// </summary>
    [HttpPost("check-email")]
    [AllowAnonymous]
    public async Task<IActionResult> CheckEmailExists([FromBody] CheckEmailRequest request)
    {
        if (string.IsNullOrEmpty(request.Email))
            return BadRequest(new { message = "Email is required" });

        try
        {
            var exists = await _authService.UserExistsAsync(request.Email);
            return Ok(new
            {
                message = "Email check completed",
                email = request.Email,
                exists = exists
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Обновить профиль пользователя
    /// </summary>
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var userIdClaim = User.FindFirst("nameid") ?? User.FindFirst("sub");
            if (userIdClaim == null)
                return Unauthorized(new { message = "User ID not found in token" });

            if (!Guid.TryParse(userIdClaim.Value, out var currentUserId))
                return BadRequest(new { message = "Invalid user ID format" });

            // Пользователь может обновлять только свой профиль, если он не админ
            var isAdmin = User.FindFirst("role")?.Value == "Admin";
            if (currentUserId != id && !isAdmin)
                return Forbid();

            var success = await _userService.UpdateUserAsync(id, updateDto);
            if (!success)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "User updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Обновить свой профиль (текущего пользователя)
    /// </summary>
    [HttpPut("me/profile")]
    [Authorize]
    public async Task<IActionResult> UpdateMyProfile([FromBody] UserUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var userIdClaim = User.FindFirst("nameid") ?? User.FindFirst("sub");
            if (userIdClaim == null)
                return Unauthorized(new { message = "User ID not found in token" });

            if (!Guid.TryParse(userIdClaim.Value, out var userId))
                return BadRequest(new { message = "Invalid user ID format" });

            var success = await _userService.UpdateUserAsync(userId, updateDto);
            if (!success)
                return NotFound(new { message = "User not found" });

            // Получить обновленные данные пользователя
            var updatedUser = await _userService.GetUserByIdAsync(userId);

            return Ok(new
            {
                message = "Your profile updated successfully",
                data = updatedUser
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Удалить пользователя (только для админов)
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "User deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Удалить свой аккаунт (текущего пользователя)
    /// </summary>
    [HttpDelete("me/account")]
    [Authorize]
    public async Task<IActionResult> DeleteMyAccount()
    {
        try
        {
            var userIdClaim = User.FindFirst("nameid") ?? User.FindFirst("sub");
            if (userIdClaim == null)
                return Unauthorized(new { message = "User ID not found in token" });

            if (!Guid.TryParse(userIdClaim.Value, out var userId))
                return BadRequest(new { message = "Invalid user ID format" });

            var success = await _userService.DeleteUserAsync(userId);
            if (!success)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "Your account has been deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    /// <summary>
    /// Проверить доступность email при регистрации
    /// </summary>
    [HttpPost("validate-email")]
    [AllowAnonymous]
    public async Task<IActionResult> ValidateEmail([FromBody] ValidateEmailRequest request)
    {
        if (string.IsNullOrEmpty(request.Email))
            return BadRequest(new { message = "Email is required" });

        try
        {
            // Проверить формат email
            try
            {
                var addr = new System.Net.Mail.MailAddress(request.Email);
                if (addr.Address != request.Email)
                    return BadRequest(new { message = "Email format is invalid" });
            }
            catch
            {
                return BadRequest(new { message = "Email format is invalid" });
            }

            var exists = await _authService.UserExistsAsync(request.Email);
            if (exists)
                return BadRequest(new { message = "Email already exists" });

            return Ok(new { message = "Email is available" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}

public record CheckEmailRequest(string Email);
public record ValidateEmailRequest(string Email);
