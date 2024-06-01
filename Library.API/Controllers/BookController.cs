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

    [HttpGet]
    [Route("GetAllBooks")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetAllBooks()
    {
        var books = await _bookInterface.GetAllBooks();

        return Ok(books);
    }

    [HttpGet]
    [Route("GetBookById/{idBook}")]
    public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int idBook)
    {
        var book = await _bookInterface.GetBookById(idBook);

        return Ok(book);
    }

    [HttpGet]
    [Route("GetBookByIdAuthor/{idAuthor}")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBookByIdAuthor(int idAuthor)
    {
        var book = await _bookInterface.GetBookByIdAuthor(idAuthor);

        return Ok(book);
    }

    [HttpPost]
    [Route("CreateBook")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookCreationDto bookCreationDto)
    {
        var book = await _bookInterface.CreateBook(bookCreationDto);

        return Ok(book);
    }

    [HttpPut]
    [Route("UpdateBook")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateBook(BookEditionDto bookEditionDto)
    {
        var book = await _bookInterface.UpdateBook(bookEditionDto);

        return Ok(book);
    }

    [HttpDelete]
    [Route("DeleteBook/{idBook}")]
    public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int idBook)
    {
        var book = await _bookInterface.DeleteBook(idBook);

        return Ok(book);
    }
}
