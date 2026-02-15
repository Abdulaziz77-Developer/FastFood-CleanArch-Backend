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
            }
        );
    }
}