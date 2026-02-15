using AutoMapper;
using FastFoodApp.Application.DTOs.CategoryDTO;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Core.Entities;
using FastFoodApp.Core.Interfaces;

namespace FastFoodApp.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
    }

    public async Task<CategoryReadDto?> GetCategoryByIdAsync(Guid id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) return null;

        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        var category = _mapper.Map<Category>(categoryCreateDto);
        
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<bool> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) return false;

        _mapper.Map(categoryUpdateDto, category);
        
        _unitOfWork.Categories.Update(category);
        
        // SaveChangesAsync возвращает количество измененных строк
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        
        if (category == null) return false;

        // Если в репозитории метод называется Remove, замени Delete на Remove
        _unitOfWork.Categories.Delete(category);
        
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0;
    }
}