using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Interfaces;
public interface ICustomerRepository
{
    Task<Customer?> GetByUserIdAsync(Guid userId);
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task<IEnumerable<Customer>> GetByCityAsync(string city);
}