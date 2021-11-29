using System.Data.SqlClient;
using Dapper;
using DataAccess.Repositories;
using MySql.Data.MySqlClient;
using NewWebAPIdotnet6.Models;

namespace NewWebAPIdotnet6.Services;

public interface IFilmService
{
    List<Film> GetFilms();
    Film GetFilm(int? id);
    Film? AddFilm(Film film);
    Film DeleteFilm(int id);
    Film? UpdateFilm(Film film);
}

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;

    public FilmService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }
    
    public List<Film> GetFilms() => _filmRepository.GetFilms();

    public Film GetFilm(int? id) => _filmRepository.GetFilm(id);
    
    public Film? AddFilm(Film film)
    {
        return _filmRepository.AddFilm(film);
    }

    public Film DeleteFilm(int id)
    {
        return _filmRepository.DeleteFilm(id);
    }

    public Film? UpdateFilm(Film film)
    {
        return _filmRepository.UpdateFilm(film);
    }
}