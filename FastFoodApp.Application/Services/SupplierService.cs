using AutoMapper;
using FastFoodApp.Application.DTOs.SupplierDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;

namespace FastFoodApp.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierReadDto>> GetAllSuppliersAsync()
    {
        var suppliers = await _unitOfWork.Suppliers.GetAllAsync();
        return _mapper.Map<IEnumerable<SupplierReadDto>>(suppliers);
    }

    public async Task<SupplierReadDto?> GetSupplierByIdAsync(Guid id)
    {
        var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (supplier == null) return null;

        return _mapper.Map<SupplierReadDto>(supplier);
    }

    public async Task<SupplierReadDto?> GetSupplierByUserIdAsync(Guid userId)
    {
        var supplier = await _unitOfWork.Suppliers.GetByUserIdAsync(userId);
        if (supplier == null) return null;

        return _mapper.Map<SupplierReadDto>(supplier);
    }

    public async Task<IEnumerable<SupplierReadDto>> GetSuppliersByCityAsync(string city)
    {
        var suppliers = await _unitOfWork.Suppliers.GetByCityAsync(city);
        return _mapper.Map<IEnumerable<SupplierReadDto>>(suppliers);
    }

    public async Task<SupplierReadDto> CreateSupplierAsync(SupplierCreateDto supplierCreateDto)
    {
        var supplier = _mapper.Map<Supplier>(supplierCreateDto);
        
        await _unitOfWork.Suppliers.AddAsync(supplier);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<SupplierReadDto>(supplier);
    }

    public async Task<bool> UpdateSupplierAsync(Guid id, SupplierUpdateDto supplierUpdateDto)
    {
        var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (supplier == null) return false;

        _mapper.Map(supplierUpdateDto, supplier);
        
        await _unitOfWork.Suppliers.UpdateAsync(supplier);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }
}
