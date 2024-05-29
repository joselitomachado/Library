using Library.API.Models;

namespace Library.API.Services.Author;

public interface IAuthorInterface
{
    Task<ResponseModel<List<AuthorModel>>> GetAllAuthors();
    Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
    Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook);
}
