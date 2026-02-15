using AutoMapper;
using FastFoodApp.Application.DTOs.CustomerDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;

namespace FastFoodApp.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CustomerReadDto?> GetCustomerByUserIdAsync(Guid userId)
    {
        var customer = await _unitOfWork.Customers.GetByUserIdAsync(userId);
        if (customer == null) return null;

        return _mapper.Map<CustomerReadDto>(customer);
    }

    public async Task<IEnumerable<CustomerReadDto>> GetCustomersByCityAsync(string city)
    {
        var customers = await _unitOfWork.Customers.GetByCityAsync(city);
        return _mapper.Map<IEnumerable<CustomerReadDto>>(customers);
    }

    public async Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
        var customer = _mapper.Map<Customer>(customerCreateDto);
        
        await _unitOfWork.Customers.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<CustomerReadDto>(customer);
    }

    public async Task<bool> UpdateCustomerAsync(Guid userId, CustomerUpdateDto customerUpdateDto)
    {
        var customer = await _unitOfWork.Customers.GetByUserIdAsync(userId);
        if (customer == null) return false;

        _mapper.Map(customerUpdateDto, customer);
        
        await _unitOfWork.Customers.UpdateAsync(customer);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }
}
