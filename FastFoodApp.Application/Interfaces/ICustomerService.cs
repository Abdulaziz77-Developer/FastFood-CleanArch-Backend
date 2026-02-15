using FastFoodApp.Application.DTOs.CustomerDTO;

namespace FastFoodApp.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerReadDto?> GetCustomerByUserIdAsync(Guid userId);
    Task<IEnumerable<CustomerReadDto>> GetCustomersByCityAsync(string city);
    Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
    Task<bool> UpdateCustomerAsync(Guid userId, CustomerUpdateDto customerUpdateDto);
}
