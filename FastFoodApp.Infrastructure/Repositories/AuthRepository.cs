using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;
using FastFoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodApp.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserByProviderIdAsync(string provider, string providerId)
    {
        // На данный момент используем email как идентификатор, 
        // но метод готов для расширения полями ExternalId
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == providerId);
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
}