using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentMethodToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440014"), "Desserts" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440015"), "Appetizers" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440016"), "Pasta" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440017"), "Seafood" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440018"), "Soups" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440019"), "Sandwiches" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440035"), new Guid("550e8400-e29b-41d4-a716-446655440011"), "Juicy burger with beef patty, BBQ sauce, and crispy bacon", "https://example.com/bbq-burger.jpg", true, "BBQ Burger", 11.99m, new Guid("550e8400-e29b-41d4-a716-446655440021") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440036"), new Guid("550e8400-e29b-41d4-a716-446655440010"), "Pizza with pineapple, ham, tomato sauce, and mozzarella", "https://example.com/hawaiian-pizza.jpg", true, "Hawaiian Pizza", 15.99m, new Guid("550e8400-e29b-41d4-a716-446655440020") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440037"), new Guid("550e8400-e29b-41d4-a716-446655440012"), "Fresh salad with feta cheese, olives, tomatoes, and cucumbers", "https://example.com/greek-salad.jpg", true, "Greek Salad", 9.49m, new Guid("550e8400-e29b-41d4-a716-446655440021") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440038"), new Guid("550e8400-e29b-41d4-a716-446655440011"), "Two beef patties with double cheddar cheese and all the toppings", "https://example.com/double-cheeseburger.jpg", true, "Double Cheeseburger", 13.99m, new Guid("550e8400-e29b-41d4-a716-446655440021") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440039"), new Guid("550e8400-e29b-41d4-a716-446655440010"), "Pizza loaded with fresh vegetables, tomato sauce, and mozzarella", "https://example.com/veggie-pizza.jpg", true, "Veggie Pizza", 13.49m, new Guid("550e8400-e29b-41d4-a716-446655440020") }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440060"),
                columns: new[] { "CreatedAt", "PaymentMethod" },
                values: new object[] { new DateTime(2026, 3, 3, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(3754), "" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440061"),
                columns: new[] { "CreatedAt", "PaymentMethod" },
                values: new object[] { new DateTime(2026, 3, 2, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4147), "" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeliveryAddress", "PaymentMethod", "Status", "TotalAmount", "UserId" },
                values: new object[] { new Guid("550e8400-e29b-41d4-a716-446655440066"), new DateTime(2026, 2, 26, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4324), "123 Main Street, Apt 4B, New York", "", "Delivered", 22.98m, new Guid("550e8400-e29b-41d4-a716-446655440000") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440000"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440001"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440002"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440003"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440004"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440005"), new DateTime(2026, 2, 21, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6193), "sarah.johnson@example.com", "Sarah Johnson", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440006"), new DateTime(2026, 2, 23, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6209), "michael.smith@example.com", "Michael Smith", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440007"), new DateTime(2026, 2, 26, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6215), "emily.davis@example.com", "Emily Davis", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 3 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440008"), new DateTime(2026, 2, 28, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6221), "robert.wilson@example.com", "Robert Wilson", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440009"), new DateTime(2026, 3, 2, 6, 28, 17, 314, DateTimeKind.Utc).AddTicks(6226), "jessica.martinez@example.com", "Jessica Martinez", "$2a$11$4e1jY8Zzv4vYf6gblK4gWe8r7q3K2m9Zc8x5V3k1q2w3e4r5t6y7u8i9o0p", 1 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Phone", "UserId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440051"), "456 Oak Avenue, Suite 200", "Los Angeles", "+1-555-0200", new Guid("550e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440052"), "789 Pine Road, Building C", "Chicago", "+1-555-0300", new Guid("550e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440053"), "321 Elm Street, Floor 5", "Houston", "+1-555-0400", new Guid("550e8400-e29b-41d4-a716-446655440008") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440054"), "654 Maple Drive, Unit 12", "Phoenix", "+1-555-0500", new Guid("550e8400-e29b-41d4-a716-446655440009") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440055"), "987 Cedar Lane, Apt 7", "Philadelphia", "+1-555-0600", new Guid("550e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440056"), "135 Birch Way, Suite 101", "San Antonio", "+1-555-0700", new Guid("550e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440057"), "246 Spruce Circle, #15", "San Diego", "+1-555-0800", new Guid("550e8400-e29b-41d4-a716-446655440008") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440058"), "357 Walnut Plaza, Unit 20", "Dallas", "+1-555-0900", new Guid("550e8400-e29b-41d4-a716-446655440009") }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "FoodId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440080"), new Guid("550e8400-e29b-41d4-a716-446655440033"), new Guid("550e8400-e29b-41d4-a716-446655440066"), 10.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440081"), new Guid("550e8400-e29b-41d4-a716-446655440034"), new Guid("550e8400-e29b-41d4-a716-446655440066"), 8.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeliveryAddress", "PaymentMethod", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440062"), new DateTime(2026, 3, 3, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4299), "456 Oak Avenue, Suite 200, Los Angeles", "", "Pending", 34.97m, new Guid("550e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440063"), new DateTime(2026, 3, 1, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4305), "789 Pine Road, Building C, Chicago", "", "Delivered", 25.98m, new Guid("550e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440064"), new DateTime(2026, 3, 2, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4314), "321 Elm Street, Floor 5, Houston", "", "In Progress", 40.47m, new Guid("550e8400-e29b-41d4-a716-446655440008") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440065"), new DateTime(2026, 2, 28, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4320), "654 Maple Drive, Unit 12, Phoenix", "", "Cancelled", 33.97m, new Guid("550e8400-e29b-41d4-a716-446655440009") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440067"), new DateTime(2026, 3, 2, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4329), "456 Oak Avenue, Suite 200, Los Angeles", "", "Pending", 29.98m, new Guid("550e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440068"), new DateTime(2026, 2, 27, 6, 28, 17, 290, DateTimeKind.Utc).AddTicks(4333), "789 Pine Road, Building C, Chicago", "", "Delivered", 44.96m, new Guid("550e8400-e29b-41d4-a716-446655440006") }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "City", "ImageUrl", "RestaurantName", "UserId" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440022"), "Chicago", "https://example.com/taco-fiesta.jpg", "Taco Fiesta", new Guid("550e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440023"), "Houston", "https://example.com/sushi-paradise.jpg", "Sushi Paradise", new Guid("550e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440024"), "Phoenix", "https://example.com/pasta-house.jpg", "Pasta House", new Guid("550e8400-e29b-41d4-a716-446655440007") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440025"), "Philadelphia", "https://example.com/bbq-smokehouse.jpg", "BBQ Smokehouse", new Guid("550e8400-e29b-41d4-a716-446655440008") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440026"), "San Antonio", "https://example.com/thai-kitchen.jpg", "Thai Kitchen", new Guid("550e8400-e29b-41d4-a716-446655440009") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440027"), "San Diego", "https://example.com/greek-taverna.jpg", "Greek Taverna", new Guid("550e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440028"), "Dallas", "https://example.com/kebab-express.jpg", "Kebab Express", new Guid("550e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("550e8400-e29b-41d4-a716-446655440029"), "Austin", "https://example.com/vegan-delights.jpg", "Vegan Delights", new Guid("550e8400-e29b-41d4-a716-446655440008") }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "FoodId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440073"), new Guid("550e8400-e29b-41d4-a716-446655440030"), new Guid("550e8400-e29b-41d4-a716-446655440062"), 12.99m, 2 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440074"), new Guid("550e8400-e29b-41d4-a716-446655440034"), new Guid("550e8400-e29b-41d4-a716-446655440062"), 8.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440075"), new Guid("550e8400-e29b-41d4-a716-446655440031"), new Guid("550e8400-e29b-41d4-a716-446655440063"), 14.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440076"), new Guid("550e8400-e29b-41d4-a716-446655440033"), new Guid("550e8400-e29b-41d4-a716-446655440063"), 10.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440077"), new Guid("550e8400-e29b-41d4-a716-446655440032"), new Guid("550e8400-e29b-41d4-a716-446655440064"), 9.99m, 3 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440078"), new Guid("550e8400-e29b-41d4-a716-446655440034"), new Guid("550e8400-e29b-41d4-a716-446655440064"), 8.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440079"), new Guid("550e8400-e29b-41d4-a716-446655440030"), new Guid("550e8400-e29b-41d4-a716-446655440065"), 12.99m, 2 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440082"), new Guid("550e8400-e29b-41d4-a716-446655440031"), new Guid("550e8400-e29b-41d4-a716-446655440067"), 14.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440083"), new Guid("550e8400-e29b-41d4-a716-446655440032"), new Guid("550e8400-e29b-41d4-a716-446655440067"), 9.99m, 1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440084"), new Guid("550e8400-e29b-41d4-a716-446655440030"), new Guid("550e8400-e29b-41d4-a716-446655440068"), 12.99m, 2 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440085"), new Guid("550e8400-e29b-41d4-a716-446655440031"), new Guid("550e8400-e29b-41d4-a716-446655440068"), 14.99m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440014"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440015"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440016"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440017"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440018"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440019"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440051"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440052"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440053"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440054"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440055"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440056"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440057"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440058"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440035"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440036"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440037"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440038"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440039"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440073"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440074"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440075"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440076"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440077"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440078"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440079"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440080"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440081"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440082"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440083"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440084"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440085"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440022"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440023"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440024"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440025"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440026"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440027"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440028"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440029"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440062"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440063"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440064"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440065"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440066"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440067"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440068"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440007"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440005"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440006"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440008"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440009"));

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440060"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 16, 13, 43, 193, DateTimeKind.Utc).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440061"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 16, 13, 43, 193, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440000"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440001"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440002"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440003"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("550e8400-e29b-41d4-a716-446655440004"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 16, 13, 43, 206, DateTimeKind.Utc).AddTicks(5012));
        }
    }
}
