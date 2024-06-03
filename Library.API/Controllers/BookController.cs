using Library.API.DTOs.Book;
using Library.API.Models;
using Library.API.Services.Book;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookInterface _bookInterface;

    public BookController(IBookInterface bookInterface)
    {
        _bookInterface = bookInterface;
    }

    /// <summary>
    /// Obter todos os livros
    /// </summary>
    /// <returns>Coleção de livros</returns>
    [HttpGet]
    [Route("GetAllBooks")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetAllBooks()
    {
        var books = await _bookInterface.GetAllBooks();

        return Ok(books);
    }

    /// <summary>
    /// Obter um livro
    /// </summary>
    /// <param name="idBook">Identificador do livro</param>
    /// <returns>Dados do livro</returns>
    [HttpGet]
    [Route("GetBookById/{idBook}")]
    public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int idBook)
    {
        var book = await _bookInterface.GetBookById(idBook);

        return Ok(book);
    }

    /// <summary>
    /// Obter um livro pelo ID do autor
    /// </summary>
    /// <param name="idAuthor">Identificador do autor</param>
    /// <returns>Dados do livro</returns>
    [HttpGet]
    [Route("GetBookByIdAuthor/{idAuthor}")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBookByIdAuthor(int idAuthor)
    {
        var book = await _bookInterface.GetBookByIdAuthor(idAuthor);

        return Ok(book);
    }

    /// <summary>
    /// Criar um livro
    /// </summary>
    /// <remarks>
    /// { "title": "string", "author": { "id":0 } }
    /// </remarks>
    /// <param name="bookCreationDto">Dados do livro</param>
    /// <returns>Objeto recém-criado</returns>
    [HttpPost]
    [Route("CreateBook")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookCreationDto bookCreationDto)
    {
        var book = await _bookInterface.CreateBook(bookCreationDto);

        return Ok(book);
    }

    /// <summary>
    /// Atualizar um livro
    /// </summary>
    /// <remarks>
    /// { "title": "string", "author": { "id": 0, "name": "string", "lastName": "string" } }
    /// </remarks>
    /// <param name="bookEditionDto">Dados do livro</param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateBook")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateBook(BookEditionDto bookEditionDto)
    {
        var book = await _bookInterface.UpdateBook(bookEditionDto);

        return Ok(book);
    }

    /// <summary>
    /// Deletar um livro
    /// </summary>
    /// <param name="idBook">Identificador do livro</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("DeleteBook/{idBook}")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int idBook)
    {
        var book = await _bookInterface.DeleteBook(idBook);

        return Ok(book);
    }
}
