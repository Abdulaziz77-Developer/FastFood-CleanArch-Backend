using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;
using FastFoodApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodApp.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _context;
    public SupplierRepository(AppDbContext context) => _context = context;

    public async Task<Supplier?> GetByIdAsync(Guid id) =>
        await _context.Suppliers.Include(s => s.Foods).FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Supplier?> GetByUserIdAsync(Guid userId) =>
        await _context.Suppliers.FirstOrDefaultAsync(s => s.UserId == userId);

    public async Task<IEnumerable<Supplier>> GetAllAsync() =>
        await _context.Suppliers.ToListAsync();

    public async Task<IEnumerable<Supplier>> GetByCityAsync(string city) =>
        await _context.Suppliers
            .Where(s => s.City.ToLower() == city.ToLower())
            .ToListAsync();

    public async Task AddAsync(Supplier supplier) => await _context.Suppliers.AddAsync(supplier);

    public async Task UpdateAsync(Supplier supplier) => _context.Suppliers.Update(supplier);
}