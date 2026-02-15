using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;
using FastFoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodApp.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task UpdateAsync(Category category)
    {
        await Task.FromResult(_context.Categories.Update(category));
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null) _context.Categories.Remove(category);
    }

    public void Delete(Category category)
    {
        _context.Categories.Remove(category);
    }
}