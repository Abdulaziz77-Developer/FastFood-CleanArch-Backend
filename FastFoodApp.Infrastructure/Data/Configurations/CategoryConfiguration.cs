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
    }
}