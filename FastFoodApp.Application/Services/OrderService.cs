using AutoMapper;
using FastFoodApp.Application.DTOs.OrderDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;

namespace FastFoodApp.Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OrderReadDto?> GetOrderByIdAsync(Guid id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order == null) return null;

        return _mapper.Map<OrderReadDto>(order);
    }

    public async Task<IEnumerable<OrderReadDto>> GetUserOrdersAsync(Guid userId)
    {
        var orders = await _unitOfWork.Orders.GetUserOrdersAsync(userId);
        return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
    }

    public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllOrdersAsync();
        return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
    }

    public async Task<IEnumerable<OrderReadDto>> GetOrdersByStatusAsync(string status)
    {
        var orders = await _unitOfWork.Orders.GetOrdersByStatusAsync(status);
        return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
    }

    public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        var order = _mapper.Map<Order>(orderCreateDto);
        
        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<OrderReadDto>(order);
    }

    public async Task<bool> UpdateOrderStatusAsync(Guid orderId, string newStatus)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
        if (order == null) return false;

        await _unitOfWork.Orders.UpdateStatusAsync(orderId, newStatus);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }
}
