namespace FastFoodApp.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IAuthRepository Auth { get; }
    IFoodRepository Foods { get; }
    IOrderRepository Orders { get; }
    ICategoryRepository Categories { get; }
    ISupplierRepository Suppliers { get; }
    ICustomerRepository Customers { get; }
    
    Task<int> SaveChangesAsync(); // Сохранить всё одной транзакцией
}