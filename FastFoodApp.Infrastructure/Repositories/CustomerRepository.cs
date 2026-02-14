using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;
using FastFoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodApp.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context) => _context = context;

    public async Task<Customer?> GetByUserIdAsync(Guid userId) =>
        await _context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.UserId == userId);

    public async Task AddAsync(Customer customer) => await _context.Customers.AddAsync(customer);

    public async Task UpdateAsync(Customer customer) => _context.Customers.Update(customer);

    public async Task<IEnumerable<Customer>> GetByCityAsync(string city) =>
        await _context.Customers.Where(c => c.City.ToLower() == city.ToLower()).ToListAsync();
}