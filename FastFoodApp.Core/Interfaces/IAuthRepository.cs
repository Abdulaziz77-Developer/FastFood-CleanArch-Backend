using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Interfaces;

public interface IAuthRepository
{
    // Поиск пользователя по Email
    Task<User?> GetUserByEmailAsync(string email);
    
    // Поиск по внешнему ID (например, Google ID), чтобы не плодить дубликаты
    Task<User?> GetUserByProviderIdAsync(string provider, string providerId);
    
    // Создание пользователя при первой авторизации через соцсети
    Task CreateUserAsync(User user);

    // Можно добавить методы для работы с Refresh-токенами в будущем
    // Task SaveRefreshTokenAsync(Guid userId, string token);
}