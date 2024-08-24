using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository;

public class BookRepository(BookStoreContext context) : IBookRepository
{
    private readonly BookStoreContext context = context;

    public async Task<Guid> AddBookAsync(BookModel bookmodel)
    {
        var book = new Book
        {
            Description = bookmodel.Description,
            Title = bookmodel.Title,
            CategoryId = bookmodel.CategoryId,
        };

        await this.context.Books.AddAsync(book);
        await this.context.SaveChangesAsync();
        return book.Id;
    }

    public async Task<bool> DeleteBookByIdAsync(Guid id)
    {
        var book = new Book { Id = id };

        this.context.Books.Remove(book);
        try
        {
            await this.context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteMultipleBooksAsync(List<Guid> bookIds)
    {
        var books = new List<Book>();
        foreach (var bookId in bookIds)
        {
            books.Add(new Book { Id = bookId });
        }

        this.context.Books.RemoveRange(books);
        try
        {
            await this.context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<List<BookModel>> GetAllBooksAsync()
    {
        //var books = await this.context.Books.ToListAsync();
        var books = await this.context.Books.Include(a => a.Category).AsNoTracking().ToListAsync();

        return books.Select(a => new BookModel(a.Id, a.CategoryId, a.Title, a.Description))
           .ToList();
    }

    public Task<Guid> UpdateBookAsync(BookModel bookmodel)
    {
        throw new NotImplementedException();
    }
}
