using Library.API.Models;
using Library.API.Services.Author;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorInterface _authorInterface;

    public AuthorController(IAuthorInterface authorInterface)
    {
        _authorInterface = authorInterface;
    }

    [HttpGet]
    [Route("GetAllAuthors")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAllAuthors()
    {
        var authors = await _authorInterface.GetAllAuthors();

        return Ok(authors);
    }

    [HttpGet]
    [Route("GetAuthorById/{idAuthor}")]
    public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int idAuthor)
    {
        var author = await _authorInterface.GetAuthorById(idAuthor);

        return Ok(author);
    }

    [HttpGet]
    [Route("GetAuthorByIdBook/{idBook}")]
    public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByIdBook(int idBook)
    {
        var author = await _authorInterface.GetAuthorByIdBook(idBook);

        return Ok(author);
    }
}
