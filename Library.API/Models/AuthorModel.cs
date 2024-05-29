using System.Text.Json.Serialization;

namespace Library.API.Models;

public class AuthorModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<BookModel> Books { get; set; } = [];
}