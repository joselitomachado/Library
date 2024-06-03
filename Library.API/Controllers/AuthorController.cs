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

    /// <summary>
    /// Obter todos os autores
    /// </summary>
    /// <returns>Coleção de autores</returns>
    [HttpGet]
    [Route("GetAllAuthors")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAllAuthors()
    {
        var authors = await _authorInterface.GetAllAuthors();

        return Ok(authors);
    }

    /// <summary>
    /// Obter um autor
    /// </summary>
    /// <param name="idAuthor">Identificador do autor</param>
    /// <returns>Dados do autor</returns>
    [HttpGet]
    [Route("GetAuthorById/{idAuthor}")]
    public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int idAuthor)
    {
        var author = await _authorInterface.GetAuthorById(idAuthor);

        return Ok(author);
    }

    /// <summary>
    /// Obter um autor pelo ID do livro
    /// </summary>
    /// <param name="idBook">Identificador do livro</param>
    /// <returns>Dados do autor</returns>
    [HttpGet]
    [Route("GetAuthorByIdBook/{idBook}")]
    public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByIdBook(int idBook)
    {
        var author = await _authorInterface.GetAuthorByIdBook(idBook);

        return Ok(author);
    }

    /// <summary>
    /// Criar um autor
    /// </summary>
    /// <remarks>
    /// { "name": "string", "lastName": "string" }
    /// </remarks>
    /// <param name="authorCreationDto">Dados do autor</param>
    /// <returns>Objeto recém-criado</returns>
    [HttpPost]
    [Route("CreateAuthor")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreationDto authorCreationDto)
    {
        var authors = await _authorInterface.CreateAuthor(authorCreationDto);

        return Ok(authors);
    }

    /// <summary>
    /// Atualizar um autor
    /// </summary>
    /// <remarks>
    /// { "id": 0, "name": "string", "lastName": "string" }
    /// </remarks>
    /// <param name="authorEditionDto">Dados do autor</param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateAuthor")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> UpdateAuthor(AuthorEditionDto authorEditionDto)
    {
        var authors = await _authorInterface.UpdateAuthor(authorEditionDto);

        return Ok(authors);
    }

    /// <summary>
    /// Deletar um autor
    /// </summary>
    /// <param name="idAuthor">Identificador do autor</param>
    /// <returns>Nada</returns>
    [HttpDelete]
    [Route("DeleteAuthor")]
    public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int idAuthor)
    {
        var authors = await _authorInterface.DeleteAuthor(idAuthor);

        return Ok(authors);
    }
}
