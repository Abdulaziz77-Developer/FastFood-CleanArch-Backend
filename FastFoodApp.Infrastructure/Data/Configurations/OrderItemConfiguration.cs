using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        
        builder.Property(oi => oi.Price).HasPrecision(18, 2);
        builder.Property(oi => oi.Quantity).IsRequired();

        // Связь с Заказом
        builder.HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId);

        // Связь с Едой
        builder.HasOne(oi => oi.Food)
               .WithMany() // У еды нет списка OrderItems (нам это не нужно)
               .HasForeignKey(oi => oi.FoodId)
               .OnDelete(DeleteBehavior.Restrict); // Нельзя удалить еду, если она есть в заказах

        // Demo data
        var orderId1 = new Guid("550e8400-e29b-41d4-a716-446655440060");
        var orderId2 = new Guid("550e8400-e29b-41d4-a716-446655440061");
        var orderId3 = new Guid("550e8400-e29b-41d4-a716-446655440062");
        var orderId4 = new Guid("550e8400-e29b-41d4-a716-446655440063");
        var orderId5 = new Guid("550e8400-e29b-41d4-a716-446655440064");
        var orderId6 = new Guid("550e8400-e29b-41d4-a716-446655440065");
        var orderId7 = new Guid("550e8400-e29b-41d4-a716-446655440066");
        var orderId8 = new Guid("550e8400-e29b-41d4-a716-446655440067");
        var orderId9 = new Guid("550e8400-e29b-41d4-a716-446655440068");
        var foodId1 = new Guid("550e8400-e29b-41d4-a716-446655440030"); // Margherita
        var foodId2 = new Guid("550e8400-e29b-41d4-a716-446655440031"); // Pepperoni
        var foodId3 = new Guid("550e8400-e29b-41d4-a716-446655440032"); // Classic Burger
        var foodId4 = new Guid("550e8400-e29b-41d4-a716-446655440033"); // Cheeseburger
        var foodId5 = new Guid("550e8400-e29b-41d4-a716-446655440034"); // Caesar Salad

        builder.HasData(
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440070"),
                OrderId = orderId1,
                FoodId = foodId1,
                Quantity = 1,
                Price = 12.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440071"),
                OrderId = orderId1,
                FoodId = foodId2,
                Quantity = 1,
                Price = 14.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440072"),
                OrderId = orderId2,
                FoodId = foodId3,
                Quantity = 2,
                Price = 9.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440073"),
                OrderId = orderId3,
                FoodId = foodId1,
                Quantity = 2,
                Price = 12.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440074"),
                OrderId = orderId3,
                FoodId = foodId5,
                Quantity = 1,
                Price = 8.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440075"),
                OrderId = orderId4,
                FoodId = foodId2,
                Quantity = 1,
                Price = 14.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440076"),
                OrderId = orderId4,
                FoodId = foodId4,
                Quantity = 1,
                Price = 10.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440077"),
                OrderId = orderId5,
                FoodId = foodId3,
                Quantity = 3,
                Price = 9.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440078"),
                OrderId = orderId5,
                FoodId = foodId5,
                Quantity = 1,
                Price = 8.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440079"),
                OrderId = orderId6,
                FoodId = foodId1,
                Quantity = 2,
                Price = 12.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440080"),
                OrderId = orderId7,
                FoodId = foodId4,
                Quantity = 1,
                Price = 10.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440081"),
                OrderId = orderId7,
                FoodId = foodId5,
                Quantity = 1,
                Price = 8.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440082"),
                OrderId = orderId8,
                FoodId = foodId2,
                Quantity = 1,
                Price = 14.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440083"),
                OrderId = orderId8,
                FoodId = foodId3,
                Quantity = 1,
                Price = 9.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440084"),
                OrderId = orderId9,
                FoodId = foodId1,
                Quantity = 2,
                Price = 12.99m
            },
            new OrderItem
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440085"),
                OrderId = orderId9,
                FoodId = foodId2,
                Quantity = 2,
                Price = 14.99m
            }
        );
    }
}