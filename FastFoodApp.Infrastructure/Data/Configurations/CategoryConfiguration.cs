using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

        // Связь один-ко-многим с Food уже описана в FoodConfiguration, 
        // но здесь можно указать это явно
        builder.HasMany(c => c.Foods)
               .WithOne(f => f.Category)
               .HasForeignKey(f => f.CategoryId);

        // Demo data
        builder.HasData(
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440010"),
                Name = "Pizza"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440011"),
                Name = "Burgers"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440012"),
                Name = "Salads"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440013"),
                Name = "Beverages"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440014"),
                Name = "Desserts"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440015"),
                Name = "Appetizers"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440016"),
                Name = "Pasta"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440017"),
                Name = "Seafood"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440018"),
                Name = "Soups"
            },
            new Category
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440019"),
                Name = "Sandwiches"
            }
        );
    }
}