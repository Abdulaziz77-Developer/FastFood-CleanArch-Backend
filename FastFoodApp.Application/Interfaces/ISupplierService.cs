using FastFoodApp.Application.DTOs.SupplierDTO;

namespace FastFoodApp.Application.Interfaces;

public interface ISupplierService
{
    Task<IEnumerable<SupplierReadDto>> GetAllSuppliersAsync();
    Task<SupplierReadDto?> GetSupplierByIdAsync(Guid id);
    Task<SupplierReadDto?> GetSupplierByUserIdAsync(Guid userId);
    Task<IEnumerable<SupplierReadDto>> GetSuppliersByCityAsync(string city);
    Task<SupplierReadDto> CreateSupplierAsync(SupplierCreateDto supplierCreateDto);
    Task<bool> UpdateSupplierAsync(Guid id, SupplierUpdateDto supplierUpdateDto);
}
