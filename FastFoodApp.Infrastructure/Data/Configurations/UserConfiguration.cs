using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FullName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(u => u.Email).IsUnique(); // Уникальный Email
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.Role).HasConversion<int>(); // Храним роль как число

        // Demo data
        var customerId = new Guid("550e8400-e29b-41d4-a716-446655440000");
        var adminId = new Guid("550e8400-e29b-41d4-a716-446655440001");
        var supplierId1 = new Guid("550e8400-e29b-41d4-a716-446655440002");
        var supplierId2 = new Guid("550e8400-e29b-41d4-a716-446655440004");
        var courierId = new Guid("550e8400-e29b-41d4-a716-446655440003");

        builder.HasData(
            new User
            {
                Id = customerId,
                FullName = "John Customer",
                Email = "customer@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", // Password123!
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = adminId,
                FullName = "Admin User",
                Email = "admin@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", // Password123!
                Role = Role.Admin,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = supplierId1,
                FullName = "Pizza Palace Owner",
                Email = "pizzapalace@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", // Password123!
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = supplierId2,
                FullName = "Burger King Local Owner",
                Email = "burgerking@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", // Password123!
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = courierId,
                FullName = "Fast Courier",
                Email = "courier@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", // Password123!
                Role = Role.Courier,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440005"),
                FullName = "Sarah Johnson",
                Email = "sarah.johnson@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p",
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            },
            new User
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440006"),
                FullName = "Michael Smith",
                Email = "michael.smith@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p",
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow.AddDays(-8)
            },
            new User
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440007"),
                FullName = "Emily Davis",
                Email = "emily.davis@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p",
                Role = Role.Courier,
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new User
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440008"),
                FullName = "Robert Wilson",
                Email = "robert.wilson@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p",
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },
            new User
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440009"),
                FullName = "Jessica Martinez",
                Email = "jessica.martinez@example.com",
                PasswordHash = "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p",
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            }
        );
    }
}