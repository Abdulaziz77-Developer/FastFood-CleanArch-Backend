using FastFoodApp.Core.Interfaces;
using FastFoodApp.Infrastructure.Data;

namespace FastFoodApp.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUserRepository Users { get; }
    public IAuthRepository Auth { get; }
    public IFoodRepository Foods { get; }
    public IOrderRepository Orders { get; }
    public ICategoryRepository Categories { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        Auth = new AuthRepository(_context);
        Foods = new FoodRepository(_context);
        Orders = new OrderRepository(_context);
        Categories = new CategoryRepository(_context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}