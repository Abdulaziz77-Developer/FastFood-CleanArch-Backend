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
            }
        );
    }
}