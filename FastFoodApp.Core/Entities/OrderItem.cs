namespace FastFoodApp.Core.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } // Цена на момент покупки

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid FoodId { get; set; }
    public Food Food { get; set; } = null!;
}