namespace FastFoodApp.Core.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Processing, Shipped, Delivered
    public string DeliveryAddress { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, etc.

    // Связь с пользователем
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    // Связь с деталями заказа
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}