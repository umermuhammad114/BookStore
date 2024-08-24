using BookStore.Models;

namespace BookStore.Repository;

public interface IBookRepository
{
    Task<List<BookModel>> GetAllBooksAsync();
    Task<bool> DeleteMultipleBooksAsync(List<Guid> bookIds);
    Task<bool> DeleteBookByIdAsync(Guid id);
    Task<Guid> UpdateBookAsync(BookModel bookmodel);
    Task<Guid> AddBookAsync(BookModel bookmodel);
}
