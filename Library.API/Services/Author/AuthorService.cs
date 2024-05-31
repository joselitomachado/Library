using Library.API.Data;
using Library.API.DTOs.Author;
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

    public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreationDto authorCreationDto)
    {
        ResponseModel<List<AuthorModel>> response = new();

        try
        {
            var author = new AuthorModel()
            {
                Name = authorCreationDto.Name,
                LastName = authorCreationDto.LastName
            };

            _libraryDb.Add(author);
            await _libraryDb.SaveChangesAsync();

            response.Data = await _libraryDb.Authors.ToListAsync();
            response.Message = "Autor criado com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorEditionDto authorEditionDto)
    {
        ResponseModel<List<AuthorModel>> response = new();

        try
        {
            var author = await _libraryDb.Authors
                 .FirstOrDefaultAsync(authorDb => authorDb.Id == authorEditionDto.Id);

            if (author == null)
            {
                response.Message = "Nenhum autor localizado.";

                return response;
            }

            author.Name = authorEditionDto.Name;
            author.LastName = authorEditionDto.LastName;

            _libraryDb.Update(author);
            await _libraryDb.SaveChangesAsync();

            response.Data = await _libraryDb.Authors.ToListAsync();
            response.Message = "Autor atualizado com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor)
    {
        ResponseModel<List<AuthorModel>> response = new();

        try
        {
            var author = await _libraryDb.Authors
                .FirstOrDefaultAsync(authorDb => authorDb.Id == idAuthor);

            if (author == null)
            {
                response.Message = "Nenhum autor localizado.";

                return response;
            }

            _libraryDb.Remove(author);
            await _libraryDb.SaveChangesAsync();

            response.Data = await _libraryDb.Authors.ToListAsync();
            response.Message = "Autor removido com sucesso.";

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
