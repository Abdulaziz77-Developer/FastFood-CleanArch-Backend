namespace FastFoodApp.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IFoodRepository Foods { get; }
    IOrderRepository Orders { get; }
    ICategoryRepository Categories { get; }
    
    Task<int> SaveChangesAsync(); // Сохранить всё одной транзакцией
}