using AutoMapper;
using FastFoodApp.Application.DTOs.FoodDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;

namespace FastFoodApp.Application.Services;

public class FoodService : IFoodService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FoodService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FoodReadDto>> GetAllFoodsAsync()
    {
        // Используем GetAllAsync или специализированный метод с Include
        var foods = await _unitOfWork.Foods.GetAllAsync(); 
        return _mapper.Map<IEnumerable<FoodReadDto>>(foods);
    }

    public async Task<FoodReadDto?> GetFoodByIdAsync(Guid id)
    {
        var food = await _unitOfWork.Foods.GetByIdAsync(id);
        if (food == null) return null;
        
        return _mapper.Map<FoodReadDto>(food);
    }

    public async Task<FoodReadDto> CreateFoodAsync(FoodCreateDto foodCreateDto)
    {
        var food = _mapper.Map<Food>(foodCreateDto);
        
        await _unitOfWork.Foods.AddAsync(food);
        await _unitOfWork.SaveChangesAsync(); 
        
        // После сохранения в БД у 'food' появится Id, маппим его обратно в ReadDto
        return _mapper.Map<FoodReadDto>(food);
    }

    public async Task<bool> UpdateFoodAsync(Guid id, FoodUpdateDto foodUpdateDto)
    {
        var food = await _unitOfWork.Foods.GetByIdAsync(id);
        if (food == null) return false;

        // Маппим ИЗ DTO В существующую сущность
        _mapper.Map(foodUpdateDto, food);
        
        await _unitOfWork.Foods.UpdateAsync(food);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteFoodAsync(Guid id)
    {
        var food = await _unitOfWork.Foods.GetByIdAsync(id);
        if (food == null) return false;

        _unitOfWork.Foods.Delete(food);
        
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }

    public async Task<IEnumerable<FoodReadDto>> GetFoodsByCategoryAsync(Guid categoryId)
    {
        var foods = await _unitOfWork.Foods.GetByCategoryAsync(categoryId);
        return _mapper.Map<IEnumerable<FoodReadDto>>(foods);
    }
}