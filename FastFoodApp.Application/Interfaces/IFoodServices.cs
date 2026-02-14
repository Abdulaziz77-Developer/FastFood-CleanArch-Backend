using FastFoodApp.Application.DTOs.FoodDTO;

namespace FastFoodApp.Application.Interfaces;

public interface IFoodService
{
    Task<IEnumerable<FoodReadDto>> GetAllFoodsAsync();
    Task<FoodReadDto?> GetFoodByIdAsync(Guid id);
    Task<IEnumerable<FoodReadDto>> GetFoodsByCategoryAsync(Guid categoryId);
    Task<FoodReadDto> CreateFoodAsync(FoodCreateDto foodCreateDto);
    Task<bool> UpdateFoodAsync(Guid id, FoodUpdateDto foodUpdateDto);
    Task<bool> DeleteFoodAsync(Guid id);
}