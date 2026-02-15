using FastFoodApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FastFoodApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    // Конструктор принимает настройки (строку подключения и драйвер), 
    // которые придут из WebApi (Program.cs)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Таблицы (DbSet)
    public DbSet<User> Users => Set<User>();
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    // Конфигурируем поведение DbContext (валидация миграций)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w => 
            w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    // Настройка связей и конфигураций
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Эта строчка автоматически применяет все конфигурации 
        // из папки Data/Configurations (UserConfiguration, FoodConfiguration и т.д.)
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}