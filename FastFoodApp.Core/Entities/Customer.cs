namespace FastFoodApp.Core.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    // Просто строка, чтобы не создавать таблицу Cities
    public string City { get; set; } = string.Empty; 
}