using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public record BookModel(
        Guid Id,
        Guid CategoryId,
        [property: Required, StringLength(3)] string Title,
        string Description);
}
