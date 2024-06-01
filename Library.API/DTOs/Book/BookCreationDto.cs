using Library.API.DTOs.Link;

namespace Library.API.DTOs.Book;

public class BookCreationDto
{
    public string Title { get; set; } = string.Empty;
    public AuthorLinkDto Author { get; set; }
}
