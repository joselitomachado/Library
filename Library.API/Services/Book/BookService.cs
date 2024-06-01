using Library.API.Data;
using Library.API.DTOs.Book;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Services.Book;

public class BookService : IBookInterface
{
    private readonly LibraryDbContext _libraryDb;

    public BookService(LibraryDbContext libraryDb)
    {
        _libraryDb = libraryDb;
    }

    public async Task<ResponseModel<List<BookModel>>> GetAllBooks()
    {
        ResponseModel<List<BookModel>> response = new();

        try
        {
            var books = await _libraryDb.Books.Include(a => a.Author).ToListAsync();

            response.Data = books;
            response.Message = "Todos os livros foram coletados.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<BookModel>> GetBookById(int idBook)
    {
        ResponseModel<BookModel> response = new();

        try
        {
            var book = await _libraryDb.Books.Include(a => a.Author).FirstOrDefaultAsync(bookDb => bookDb.Id == idBook);

            if (book == null)
            {
                response.Message = "Nenhum livro encontrado.";
                return response;
            }

            response.Data = book;
            response.Message = "Livro localizado";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> GetBookByIdAuthor(int idAuthor)
    {
        ResponseModel<List<BookModel>> response = new();

        try
        {
            var books = await _libraryDb.Books
                 .Include(a => a.Author)
                 .Where(booksDb => booksDb.Author.Id == idAuthor)
                 .ToListAsync();

            if (books == null)
            {
                response.Message = "Nenhum registro localizado";
                return response;
            }

            response.Data = books;
            response.Message = "Livros localizado.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreationDto bookCreationDto)
    {
        ResponseModel<List<BookModel>> response = new();

        try
        {
            var author = await _libraryDb.Authors
                .FirstOrDefaultAsync(authorDb => authorDb.Id == bookCreationDto.Author.Id);

            if(author == null)
            {
                response.Message = "Nenhum registro de autor localizado";
                return response;
            }

            var book = new BookModel
            {
                Title = bookCreationDto.Title,
                Author = author
            };

            _libraryDb.Add(book);
            await _libraryDb.SaveChangesAsync();

            response.Data = await _libraryDb.Books.Include(a => a.Author).ToListAsync();
            response.Message = "Livro criando com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> UpdateBook(BookEditionDto bookEditionDto)
    {
        ResponseModel<List<BookModel>> response = new();

        try
        {
            var book = await _libraryDb.Books
                 .Include(a => a.Author)
                 .FirstOrDefaultAsync(bookDb => bookDb.Id == bookEditionDto.Id);

            var author = await _libraryDb.Authors
                .FirstOrDefaultAsync(authorDb => authorDb.Id == bookEditionDto.Author.Id);

            if (author == null)
            {
                response.Message = "Nenhum registro de autor localizado";
                return response;
            }

            if (book == null)
            {
                response.Message = "Nenhum registro de livro localizado";
                return response;
            }

            book.Title = bookEditionDto.Title;
            book.Author = author;

            _libraryDb.Update(book);
            await _libraryDb.SaveChangesAsync();

            response.Data = await _libraryDb.Books.ToListAsync();
            response.Message = "Livro atualizado com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;

            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook)
    {
        ResponseModel<List<BookModel>> response = new();

        try
        {
            var book = await _libraryDb.Books
                .FirstOrDefaultAsync(bookDb => bookDb.Id == idBook);

            if (book == null)
            {
                response.Message = "Nenhum livro encontrado.";
                return response;
            }

            _libraryDb.Remove(book);
            await _libraryDb.SaveChangesAsync();

            response.Data = await _libraryDb.Books
                .Include(a => a.Author)
                .ToListAsync();
            response.Message = "Livro removido com sucesso.";

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