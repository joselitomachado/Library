using Library.API.DTOs.Link;
using Library.API.Models;

namespace Library.API.DTOs.Book;

public class BookEditionDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public AuthorLinkDto Author { get; set; }
}
