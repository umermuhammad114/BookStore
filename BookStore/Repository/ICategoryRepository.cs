using BookStore.Models;

namespace BookStore.Repository;

public interface ICategoryRepository
{
    Task<List<CategoryModel>> GetAllCategoriesAsync();
    Task<bool> DeleteMultipleCategoriesAsync(List<Guid> categoryIds);
    Task<bool> DeleteCategoryByIdAsync(Guid id);
    Task<Guid> UpdateCategoryAsync(CategoryModel categoryModel);
    Task<Guid> AddCategoryAsync(CategoryModel categoryModel);
}
