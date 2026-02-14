using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Interfaces;
public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(Guid id);
    Task<Supplier?> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Supplier>> GetAllAsync();
    Task<IEnumerable<Supplier>> GetByCityAsync(string city);
    Task AddAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
}