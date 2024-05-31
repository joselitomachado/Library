using Library.API.DTOs.Author;
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

    [HttpPost]
    [Route("CreateAuthor")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreationDto authorCreationDto)
    {
        var authors = await _authorInterface.CreateAuthor(authorCreationDto);

        return Ok(authors);
    }

    [HttpPut]
    [Route("UpdateAuthor")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> UpdateAuthor(AuthorEditionDto authorEditionDto)
    {
        var authors = await _authorInterface.UpdateAuthor(authorEditionDto);

        return Ok(authors);
    }

    [HttpDelete]
    [Route("DeleteAuthor")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int idAuthor)
    {
        var authors = await _authorInterface.DeleteAuthor(idAuthor);

        return Ok(authors);
    }
}
