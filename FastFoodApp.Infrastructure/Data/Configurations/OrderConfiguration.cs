using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.TotalAmount).HasPrecision(18, 2);
        builder.Property(o => o.Status).IsRequired().HasMaxLength(20);
        builder.Property(o => o.DeliveryAddress).IsRequired().HasMaxLength(500);
        builder.Property(o => o.CreatedAt).HasDefaultValueSql("GETUTCDATE()"); // Авто-дата на уровне SQL

        // Связь: Один пользователь - Много заказов
        builder.HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Cascade); // Удалим юзера — удалятся заказы

        // Demo data
        var customerId = new Guid("550e8400-e29b-41d4-a716-446655440000");
        builder.HasData(
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440060"),
                UserId = customerId,
                TotalAmount = 27.98m,
                Status = "Pending",
                DeliveryAddress = "123 Main Street, Apt 4B, New York",
                CreatedAt = DateTime.UtcNow
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440061"),
                UserId = customerId,
                TotalAmount = 20.98m,
                Status = "Delivered",
                DeliveryAddress = "123 Main Street, Apt 4B, New York",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440062"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                TotalAmount = 34.97m,
                Status = "Pending",
                DeliveryAddress = "456 Oak Avenue, Suite 200, Los Angeles",
                CreatedAt = DateTime.UtcNow
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440063"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                TotalAmount = 25.98m,
                Status = "Delivered",
                DeliveryAddress = "789 Pine Road, Building C, Chicago",
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440064"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440008"),
                TotalAmount = 40.47m,
                Status = "In Progress",
                DeliveryAddress = "321 Elm Street, Floor 5, Houston",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440065"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440009"),
                TotalAmount = 33.97m,
                Status = "Cancelled",
                DeliveryAddress = "654 Maple Drive, Unit 12, Phoenix",
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440066"),
                UserId = customerId,
                TotalAmount = 22.98m,
                Status = "Delivered",
                DeliveryAddress = "123 Main Street, Apt 4B, New York",
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440067"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                TotalAmount = 29.98m,
                Status = "Pending",
                DeliveryAddress = "456 Oak Avenue, Suite 200, Los Angeles",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Order
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440068"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                TotalAmount = 44.96m,
                Status = "Delivered",
                DeliveryAddress = "789 Pine Road, Building C, Chicago",
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            }
        );
    }
}