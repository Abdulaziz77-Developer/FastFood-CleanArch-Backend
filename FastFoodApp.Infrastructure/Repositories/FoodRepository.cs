using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;
using FastFoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodApp.Infrastructure.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _context;
    public FoodRepository(AppDbContext context) => _context = context;

    public async Task<Food?> GetByIdAsync(Guid id) => await _context.Foods.FindAsync(id);
    public async Task<IEnumerable<Food>> GetAllAsync() => await _context.Foods.ToListAsync();
    public async Task<IEnumerable<Food>> GetAvailableFoodsAsync() => await _context.Foods.Where(f => f.IsAvailable).ToListAsync();
    
    // Метод должен называться В ТОЧНОСТИ как в интерфейсе Core
    public async Task<IEnumerable<Food>> GetByCategoryAsync(Guid categoryId) => 
        await _context.Foods.Where(f => f.CategoryId == categoryId).ToListAsync();

    public async Task AddAsync(Food food) => await _context.Foods.AddAsync(food);
    public async Task UpdateAsync(Food food) => _context.Foods.Update(food);
    public async Task DeleteAsync(Guid id) 
    {
        var food = await _context.Foods.FindAsync(id);
        if (food != null) _context.Foods.Remove(food);
    }
}