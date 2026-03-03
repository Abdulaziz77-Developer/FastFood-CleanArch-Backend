using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).IsRequired().HasMaxLength(100);
        builder.Property(f => f.Price).HasPrecision(18, 2);
        builder.Property(f => f.IsAvailable).HasDefaultValue(true); // Точность для денег
        
        // Связь с категорией
        builder.HasOne(f => f.Category)
               .WithMany(c => c.Foods)
               .HasForeignKey(f => f.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        // Demo data
        var pizzaCategoryId = new Guid("550e8400-e29b-41d4-a716-446655440010");
        var burgerCategoryId = new Guid("550e8400-e29b-41d4-a716-446655440011");
        var saladCategoryId = new Guid("550e8400-e29b-41d4-a716-446655440012");
        var supplierId1 = new Guid("550e8400-e29b-41d4-a716-446655440020");
        var supplierId2 = new Guid("550e8400-e29b-41d4-a716-446655440021");

        builder.HasData(
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440030"),
                Name = "Margherita Pizza",
                Description = "Classic pizza with tomato sauce, mozzarella, and basil",
                Price = 12.99m,
                CategoryId = pizzaCategoryId,
                SupplierId = supplierId1,
                ImageUrl = "https://example.com/margherita.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440031"),
                Name = "Pepperoni Pizza",
                Description = "Pizza with tomato sauce, mozzarella, and pepperoni",
                Price = 14.99m,
                CategoryId = pizzaCategoryId,
                SupplierId = supplierId1,
                ImageUrl = "https://example.com/pepperoni.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440032"),
                Name = "Classic Burger",
                Description = "Juicy burger with beef patty, lettuce, tomato, and special sauce",
                Price = 9.99m,
                CategoryId = burgerCategoryId,
                SupplierId = supplierId2,
                ImageUrl = "https://example.com/burger.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440033"),
                Name = "Cheeseburger",
                Description = "Burger with beef patty, cheddar cheese, and all the toppings",
                Price = 10.99m,
                CategoryId = burgerCategoryId,
                SupplierId = supplierId2,
                ImageUrl = "https://example.com/cheeseburger.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440034"),
                Name = "Caesar Salad",
                Description = "Fresh romaine lettuce with parmesan and caesar dressing",
                Price = 8.99m,
                CategoryId = saladCategoryId,
                SupplierId = supplierId1,
                ImageUrl = "https://example.com/caesar-salad.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440035"),
                Name = "BBQ Burger",
                Description = "Juicy burger with beef patty, BBQ sauce, and crispy bacon",
                Price = 11.99m,
                CategoryId = burgerCategoryId,
                SupplierId = supplierId2,
                ImageUrl = "https://example.com/bbq-burger.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440036"),
                Name = "Hawaiian Pizza",
                Description = "Pizza with pineapple, ham, tomato sauce, and mozzarella",
                Price = 15.99m,
                CategoryId = pizzaCategoryId,
                SupplierId = supplierId1,
                ImageUrl = "https://example.com/hawaiian-pizza.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440037"),
                Name = "Greek Salad",
                Description = "Fresh salad with feta cheese, olives, tomatoes, and cucumbers",
                Price = 9.49m,
                CategoryId = saladCategoryId,
                SupplierId = supplierId2,
                ImageUrl = "https://example.com/greek-salad.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440038"),
                Name = "Double Cheeseburger",
                Description = "Two beef patties with double cheddar cheese and all the toppings",
                Price = 13.99m,
                CategoryId = burgerCategoryId,
                SupplierId = supplierId2,
                ImageUrl = "https://example.com/double-cheeseburger.jpg",
                IsAvailable = true
            },
            new Food
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440039"),
                Name = "Veggie Pizza",
                Description = "Pizza loaded with fresh vegetables, tomato sauce, and mozzarella",
                Price = 13.49m,
                CategoryId = pizzaCategoryId,
                SupplierId = supplierId1,
                ImageUrl = "https://example.com/veggie-pizza.jpg",
                IsAvailable = true
            }
        );
    }
}