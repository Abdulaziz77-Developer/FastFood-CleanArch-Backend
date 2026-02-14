namespace FastFoodApp.Core.Entities;

public class Food
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    public Guid SupplierId { get; set; }

    // 2. Добавляем навигационное свойство (ссылка на сам объект поставщика)
    public Supplier? Supplier { get; set; } 

    // Связь с категорией
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}