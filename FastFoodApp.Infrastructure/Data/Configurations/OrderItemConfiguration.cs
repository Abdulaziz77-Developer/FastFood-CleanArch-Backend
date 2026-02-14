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
    }
}