using Library.API.DTOs.Book;
using Library.API.Models;

namespace Library.API.Services.Book;

public interface IBookInterface
{
    Task<ResponseModel<List<BookModel>>> GetAllBooks();
    Task<ResponseModel<BookModel>> GetBookById(int idBook);
    Task<ResponseModel<List<BookModel>>> GetBookByIdAuthor(int idAuthor);
    Task<ResponseModel<List<BookModel>>> CreateBook(BookCreationDto bookCreationDto);
    Task<ResponseModel<List<BookModel>>> UpdateBook(BookEditionDto bookEditionDto);
    Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook);
}
