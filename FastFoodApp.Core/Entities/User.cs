using FastFoodApp.Core.Enums;
namespace FastFoodApp.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    // Добавляем роль
    public Role Role { get; set; } = Role.Customer;

    // Дата создания
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Связь с заказами (один пользователь может иметь много заказов)
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}