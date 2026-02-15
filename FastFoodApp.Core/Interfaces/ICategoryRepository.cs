using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    void Update(Category category);
    Task DeleteAsync(Guid id);
    void Delete(Category category);
}