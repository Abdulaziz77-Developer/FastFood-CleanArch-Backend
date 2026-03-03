using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Address)
            .HasMaxLength(500);

        // Связь 1:1 с таблицей User
        builder.HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Customer>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Demo data
        var customerId = new Guid("550e8400-e29b-41d4-a716-446655440000");
        builder.HasData(
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440050"),
                UserId = customerId,
                Phone = "+1-555-0100",
                Address = "123 Main Street, Apt 4B",
                City = "New York"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440051"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                Phone = "+1-555-0200",
                Address = "456 Oak Avenue, Suite 200",
                City = "Los Angeles"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440052"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                Phone = "+1-555-0300",
                Address = "789 Pine Road, Building C",
                City = "Chicago"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440053"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440008"),
                Phone = "+1-555-0400",
                Address = "321 Elm Street, Floor 5",
                City = "Houston"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440054"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440009"),
                Phone = "+1-555-0500",
                Address = "654 Maple Drive, Unit 12",
                City = "Phoenix"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440055"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                Phone = "+1-555-0600",
                Address = "987 Cedar Lane, Apt 7",
                City = "Philadelphia"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440056"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                Phone = "+1-555-0700",
                Address = "135 Birch Way, Suite 101",
                City = "San Antonio"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440057"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440008"),
                Phone = "+1-555-0800",
                Address = "246 Spruce Circle, #15",
                City = "San Diego"
            },
            new Customer
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440058"),
                UserId = new Guid("550e8400-e29b-41d4-a716-446655440009"),
                Phone = "+1-555-0900",
                Address = "357 Walnut Plaza, Unit 20",
                City = "Dallas"
            }
        );
    }
}