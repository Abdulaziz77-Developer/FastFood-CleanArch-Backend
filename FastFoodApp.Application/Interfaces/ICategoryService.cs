using FastFoodApp.Application.DTOs.CategoryDTO;


namespace FastFoodApp.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync();
    Task<CategoryReadDto?> GetCategoryByIdAsync(Guid id);
    Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task<bool> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto);
    Task<bool> DeleteCategoryAsync(Guid id);
}