using Microsoft.AspNetCore.Mvc;
using NewWebAPIdotnet6.Models;
using NewWebAPIdotnet6.Services;

namespace NewWebAPIdotnet6.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private readonly IFilmService _filmService;
    
    public FilmController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet("{id?}")]
    public IActionResult Get(int? id)
    {
        if (id == null)
        {
            return Ok(_filmService.GetFilms());
        }
        return Ok(_filmService.GetFilm(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Film film)
    {
        if (film == null)
        {
            throw new TypeAccessException();
        }

        return Ok(_filmService.AddFilm(film));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_filmService.DeleteFilm(id));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Film film)
    {
        return Ok(_filmService.UpdateFilm(film));
    }
}