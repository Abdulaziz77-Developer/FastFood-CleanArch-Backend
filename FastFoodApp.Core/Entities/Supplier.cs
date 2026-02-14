namespace FastFoodApp.Core.Entities;
public class Supplier
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public string RestaurantName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    // Город поставщика
    public string City { get; set; } = string.Empty;

    public ICollection<Food> Foods { get; set; } = new List<Food>();
}