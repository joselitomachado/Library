using Library.API.Data;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Services.Author;

public class AuthorService : IAuthorInterface
{
    private readonly LibraryDbContext _libraryDb;

    public AuthorService(LibraryDbContext libraryDb)
    {
        _libraryDb = libraryDb;
    }

    public async Task<ResponseModel<List<AuthorModel>>> GetAllAuthors()
    {
        ResponseModel<List<AuthorModel>> response = new();

        try
        {
            var authors = await _libraryDb.Authors.ToListAsync();

            response.Data = authors;
            response.Message = "Todos os autores foram coletados.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor)
    {
        ResponseModel<AuthorModel> response = new();

        try
        {
            var author = await _libraryDb.Authors.FirstOrDefaultAsync(authorDb => authorDb.Id == idAuthor);

            if (author == null)
            {
                response.Message = "Nenhum registro localizado.";
                return response;
            }

            response.Data = author;
            response.Message = "Autor localizado.";

            return response;

        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook)
    {
        ResponseModel<AuthorModel> response = new();

        try
        {
            var book = await _libraryDb.Books
                .Include(a => a.Author)
                .FirstOrDefaultAsync(bookDb => bookDb.Id == idBook);

            if (book == null)
            {
                response.Message = "Nenhum registro localizado";
                return response;
            }

            response.Data = book.Author;
            response.Message = "Autor localizado.";

            return response;

        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }
}
