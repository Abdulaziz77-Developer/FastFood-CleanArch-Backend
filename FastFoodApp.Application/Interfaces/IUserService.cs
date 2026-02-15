using FastFoodApp.Application.DTOs.UserDTO;

namespace FastFoodApp.Application.Interfaces;

public interface IUserService
{
    Task<UserReadDto?> GetUserByIdAsync(Guid id);
    Task<UserReadDto?> GetUserByEmailAsync(string email);
    Task<UserReadDto> RegisterUserAsync(UserRegisterDto userRegisterDto);
    Task<bool> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
    Task<bool> DeleteUserAsync(Guid id);
    Task<bool> UserExistsAsync(string email);
}
