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
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440022"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                RestaurantName = "Taco Fiesta",
                City = "Chicago",
                ImageUrl = "https://example.com/taco-fiesta.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440023"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                RestaurantName = "Sushi Paradise",
                City = "Houston",
                ImageUrl = "https://example.com/sushi-paradise.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440024"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440007"),
                RestaurantName = "Pasta House",
                City = "Phoenix",
                ImageUrl = "https://example.com/pasta-house.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440025"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440008"),
                RestaurantName = "BBQ Smokehouse",
                City = "Philadelphia",
                ImageUrl = "https://example.com/bbq-smokehouse.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440026"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440009"),
                RestaurantName = "Thai Kitchen",
                City = "San Antonio",
                ImageUrl = "https://example.com/thai-kitchen.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440027"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                RestaurantName = "Greek Taverna",
                City = "San Diego",
                ImageUrl = "https://example.com/greek-taverna.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440028"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                RestaurantName = "Kebab Express",
                City = "Dallas",
                ImageUrl = "https://example.com/kebab-express.jpg"
            },
            new Supplier
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440029"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440008"),
                RestaurantName = "Vegan Delights",
                City = "Austin",
                ImageUrl = "https://example.com/vegan-delights.jpg"
            }
        );
    }
}