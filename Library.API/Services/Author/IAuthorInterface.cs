using Library.API.DTOs.Author;
using Library.API.Models;

namespace Library.API.Services.Author;

public interface IAuthorInterface
{
    Task<ResponseModel<List<AuthorModel>>> GetAllAuthors();
    Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
    Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook);
    Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreationDto authorCreationDto);
    Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorEditionDto authorEditionDto);
    Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor);
}
