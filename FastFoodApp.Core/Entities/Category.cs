namespace FastFoodApp.Core.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // Навигационное свойство для связи с продуктами
    public ICollection<Food> Foods { get; set; } = new List<Food>();
}