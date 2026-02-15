using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.RestaurantName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.City)
            .IsRequired()
            .HasMaxLength(100);

        // Связь 1:1 с User
        builder.HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<Supplier>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь 1:N с Food (один поставщик - много блюд)
        builder.HasMany(s => s.Foods)
            .WithOne(f => f.Supplier)
            .HasForeignKey(f => f.SupplierId)
            .OnDelete(DeleteBehavior.Restrict); // Если удалим поставщика, еду лучше обрабатывать отдельно

        // Demo data
        var supplierId = new Guid("550e8400-e29b-41d4-a716-446655440002");
        builder.HasData(
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440020"),
                UserId = supplierId,
                RestaurantName = "Pizza Palace",
                City = "New York",
                ImageUrl = "https://example.com/pizza-palace.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440021"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440004"),
                RestaurantName = "Burger King Local",
                City = "Los Angeles",
                ImageUrl = "https://example.com/burger-king.jpg"
            }
        );
    }
}