using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440010"), "Pizza" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440011"), "Burgers" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440012"), "Salads" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440013"), "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440000"), new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(4547), "customer@example.com", "John Customer", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440001"), new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5007), "admin@example.com", "Admin User", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 2 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440002"), new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5010), "pizzapalace@example.com", "Pizza Palace Owner", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440003"), new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5015), "courier@example.com", "Fast Courier", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 3 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440004"), new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5012), "burgerking@example.com", "Burger King Local Owner", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Phone", "UserId" },
                values: new object[] { new Guid("550e8400-e29b-41d4-a716-446655440050"), "123 Main Street, Apt 4B", "New York", "+1-555-0100", new Guid("550e8400-e29b-41d4-a716-446655440000") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeliveryAddress", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440060"), new DateTime(2026, 2, 15, 16, 13, 43, 193, DateTimeKind.Utc).AddTicks(3565), "123 Main Street, Apt 4B, New York", "Pending", 27.98m, new Guid("550e8400-e29b-41d4-a716-446655440000") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440061"), new DateTime(2026, 2, 14, 16, 13, 43, 193, DateTimeKind.Utc).AddTicks(4043), "123 Main Street, Apt 4B, New York", "Delivered", 20.98m, new Guid("550e8400-e29b-41d4-a716-446655440000") }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "City", "ImageUrl", "RestaurantName", "UserId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440020"), "New York", "https://example.com/pizza-palace.jpg", "Pizza Palace", new Guid("550e8400-e29b-41d4-a716-446655440002") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440021"), "Los Angeles", "https://example.com/burger-king.jpg", "Burger King Local", new Guid("550e8400-e29b-41d4-a716-446655440004") }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440030"), new Guid("550e8400-e29b-41d4-a716-446655440010"), "Classic pizza with tomato sauce, mozzarella, and basil", "https://example.com/margherita.jpg", true, "Margherita Pizza", 12.99m, new Guid("550e8400-e29b-41d4-a716-446655440020") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440031"), new Guid("550e8400-e29b-41d4-a716-446655440010"), "Pizza with tomato sauce, mozzarella, and pepperoni", "https://example.com/pepperoni.jpg", true, "Pepperoni Pizza", 14.99m, new Guid("550e8400-e29b-41d4-a716-446655440020") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440032"), new Guid("550e8400-e29b-41d4-a716-446655440011"), "Juicy burger with beef patty, lettuce, tomato, and special sauce", "https://example.com/burger.jpg", true, "Classic Burger", 9.99m, new Guid("550e8400-e29b-41d4-a716-446655440021") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440033"), new Guid("550e8400-e29b-41d4-a716-446655440011"), "Burger with beef patty, cheddar cheese, and all the toppings", "https://example.com/cheeseburger.jpg", true, "Cheeseburger", 10.99m, new Guid("550e8400-e29b-41d4-a716-446655440021") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440034"), new Guid("550e8400-e29b-41d4-a716-446655440012"), "Fresh romaine lettuce with parmesan and caesar dressing", "https://example.com/caesar-salad.jpg", true, "Caesar Salad", 8.99m, new Guid("550e8400-e29b-41d4-a716-446655440020") }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "FoodId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440070"), new Guid("550e8400-e29b-41d4-a716-446655440030"), new Guid("550e8400-e29b-41d4-a716-446655440060"), 12.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440071"), new Guid("550e8400-e29b-41d4-a716-446655440031"), new Guid("550e8400-e29b-41d4-a716-446655440060"), 14.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440072"), new Guid("550e8400-e29b-41d4-a716-446655440032"), new Guid("550e8400-e29b-41d4-a716-446655440061"), 9.99m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440013"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440050"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440033"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440034"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440070"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440071"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440072"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440003"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440012"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440030"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440031"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440032"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440060"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440061"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440010"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440011"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440020"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440021"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440000"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440004"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");
        }
    }
}
