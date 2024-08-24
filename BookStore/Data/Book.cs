namespace BookStore.Data;

public class Book
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public BookCategory Category { get; set; }
}
