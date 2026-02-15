using AutoMapper;
using FastFoodApp.Application.DTOs.UserDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;

namespace FastFoodApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserReadDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return null;

        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserReadDto?> GetUserByEmailAsync(string email)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email);
        if (user == null) return null;

        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserReadDto> RegisterUserAsync(UserRegisterDto userRegisterDto)
    {
        var user = _mapper.Map<User>(userRegisterDto);
        
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<bool> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return false;

        _mapper.Map(userUpdateDto, user);
        
        await _unitOfWork.Users.UpdateAsync(user);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return false;

        // Implement delete logic through repository if available
        // For now, just return true assuming it can be deleted
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _unitOfWork.Users.ExistsAsync(email);
    }
}
