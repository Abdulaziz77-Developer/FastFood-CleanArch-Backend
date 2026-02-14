using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodApp.Infrastructure.Data.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).IsRequired().HasMaxLength(100);
        builder.Property(f => f.Price).HasPrecision(18, 2);
        builder.Property(f => f.IsAvailable).HasDefaultValue(true); // Точность для денег
        
        // Связь с категорией
        builder.HasOne(f => f.Category)
               .WithMany(c => c.Foods)
               .HasForeignKey(f => f.CategoryId)
               .OnDelete(DeleteBehavior.Restrict); 
    }
}