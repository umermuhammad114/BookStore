namespace BookStore.Data;

public class BookCategory
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
