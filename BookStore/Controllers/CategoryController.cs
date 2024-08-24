using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    private readonly ICategoryRepository categoryRepository = categoryRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await this.categoryRepository.GetAllCategoriesAsync();
        return Ok(categories);
    }


    [HttpPost]
    public async Task<IActionResult> AddNewCategory(CategoryModel categoryModel)
    {
        var category = await this.categoryRepository.AddCategoryAsync(categoryModel);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryById(Guid id)
    {
        var isSuccess = await this.categoryRepository.DeleteCategoryByIdAsync(id);
        return Ok(isSuccess);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategories(List<Guid> ids)
    {
        var isSuccess = await this.categoryRepository.DeleteMultipleCategoriesAsync(ids);
        return Ok(isSuccess);
    }
}
