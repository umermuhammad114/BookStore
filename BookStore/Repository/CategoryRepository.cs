using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository;

public class CategoryRepository(BookStoreContext context) : ICategoryRepository
{
    private readonly BookStoreContext context = context;

    public async Task<Guid> AddCategoryAsync(CategoryModel categoryModel)
    {
        var category = new BookCategory
        {
            Title = categoryModel.Title,
        };

        await this.context.Categories.AddAsync(category);
        await this.context.SaveChangesAsync();
        return category.Id;
    }

    public async Task<bool> DeleteCategoryByIdAsync(Guid id)
    {
        //var category = await this.context.Categories
        //    .Include(a => a.Books)
        //    .FirstOrDefaultAsync(a => a.Id.Equals(id));

        //var category = new BookCategory { Id = id };

        try
        {
            using var transaction = await this.context.Database.BeginTransactionAsync();

            var books = await this.context.Books
                .Where(a => a.CategoryId.Equals(id))
                .ExecuteDeleteAsync();

            var category = await this.context.Categories
                .Where(a => a.Id.Equals(id))
                .ExecuteDeleteAsync();

            await transaction.CommitAsync();
            //if (category != null)
            //{
            //    //this.context.Categories.Remove(category);
            //    await this.context.SaveChangesAsync();
            //}
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteMultipleCategoriesAsync(List<Guid> categoryIds)
    {
        var categories = await this.context.Categories
            .Include(a => a.Books)
            .Where(a => categoryIds.Contains(a.Id))
            .ToListAsync();

        try
        {
            this.context.Categories.RemoveRange(categories);
            await this.context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<List<CategoryModel>> GetAllCategoriesAsync()
    {
        //var categories = await this.context.Categories.ToListAsync();
        var categories = await this.context.Categories.Include(a => a.Books).ToListAsync();

        return categories.Select(a => new CategoryModel(a.Id, a.Title))
           .ToList();
    }

    public async Task<Guid> UpdateCategoryAsync(CategoryModel categoryModel)
    {
        throw new NotImplementedException();
    }
}
