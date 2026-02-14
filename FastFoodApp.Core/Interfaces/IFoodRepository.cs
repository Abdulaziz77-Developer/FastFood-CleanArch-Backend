using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Interfaces;

public interface IFoodRepository
{
    Task<Food?> GetByIdAsync(Guid id);
    Task<IEnumerable<Food>> GetAllAsync();
    Task<IEnumerable<Food>> GetByCategoryAsync(Guid categoryId);
    Task<IEnumerable<Food>> GetAvailableFoodsAsync(); // Только те, что в наличии
    Task AddAsync(Food food);
    Task UpdateAsync(Food food);
    Task DeleteAsync(Guid id);
    void Update(Food food);
    void Delete(Food food);
}