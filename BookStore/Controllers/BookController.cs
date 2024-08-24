using BookStore.Authentication;
using BookStore.Enums;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BookController(IBookRepository bookRepository) : ControllerBase
{
    private readonly IBookRepository bookRepository = bookRepository;

    [HttpGet]
    [HasPermission(Permissions.GetBooks)]
    [Route("/api/[controller]/books")]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await this.bookRepository.GetAllBooksAsync();
        return Ok(books);
    }


    [HttpPost]
    [HasPermission(Permissions.AddBook)]
    public async Task<IActionResult> AddNewBook(BookModel bookmodel)
    {
        var book = await this.bookRepository.AddBookAsync(bookmodel);
        return Ok(book);
    }

    [HttpDelete("{id}")]
    [HasPermission(Permissions.DeleteBook)]
    public async Task<IActionResult> DeleteBookById(Guid id)
    {
        var isSuccess = await this.bookRepository.DeleteBookByIdAsync(id);
        return Ok(isSuccess);
    }

    [HttpDelete]
    [HasPermission(Permissions.DeleteBook)]
    public async Task<IActionResult> DeleteBooks(List<Guid> ids)
    {
        var isSuccess = await this.bookRepository.DeleteMultipleBooksAsync(ids);
        return Ok(isSuccess);
    }
}
