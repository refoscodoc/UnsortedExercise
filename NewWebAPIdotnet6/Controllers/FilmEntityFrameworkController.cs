using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using NewWebAPIdotnet6.Models;
using NewWebAPIdotnet6.Services;

namespace NewWebAPIdotnet6.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmEntityFrameworkController : ControllerBase
{
    private readonly IFilmServiceEf _filmServiceEf;
    
    public FilmEntityFrameworkController(IFilmServiceEf filmServiceEf)
    {
        _filmServiceEf = filmServiceEf;
    }

    [HttpGet("{id?}")]
    public IActionResult Get(int? id)
    {
        if (id == 0 || id == null)
        {
            return Ok(_filmServiceEf.GetFilms());
        }
        
        return Ok(_filmServiceEf.GetFilm(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Film film)
    {
        return Ok(_filmServiceEf.AddFilm(film));
    }

    [HttpPut]
    public IActionResult UpdateFilm([FromBody] Film film)
    {
        return Ok(_filmServiceEf.UpdateFilm(film));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        return Ok(_filmServiceEf.DeleteFilm(id));
    }
}