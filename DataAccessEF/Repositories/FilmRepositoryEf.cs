using NewWebAPIdotnet6.Models;

namespace DataAccessEF.Repositories;

public interface IFilmRepositoryEf
{
    List<Film> GetFilms();
    Film GetFilm(int? id);
    Film AddFilm(Film film);
    Film DeleteFilm(int id);
    Film? UpdateFilm(Film film);
}


public class FilmRepositoryEf : IFilmRepositoryEf
{
    private readonly RepositoryBaseEf _context;

    public FilmRepositoryEf(RepositoryBaseEf context)
    {
        _context = context;
    }
    public List<Film> GetFilms()
    {
        return _context.Film.ToList();
    }

    public Film GetFilm(int? id)
    {
        return _context.Film.Single(x => x.FilmId == id);
    }

    public Film AddFilm(Film film)
    {
        var newFilm = new Film
        {
            Title = film.Title,
            Description = film.Description,
            ReleaseYear = film.ReleaseYear
        };

        _context.Film.Add(newFilm);

        return newFilm;
    }

    public Film DeleteFilm(int id)
    {
        var filmToDelete = _context.Film.Single(x => x.FilmId == id);
        _context.Film.Remove(filmToDelete);

        _context.SaveChanges();

        return filmToDelete;
    }

    public Film? UpdateFilm(Film film)
    {
        // _context.Film.Update(film);

        Film? entity = _context.Film.FirstOrDefault(item => item.FilmId == film.FilmId);

        if (entity != null)
        {
            entity.Title = film.Title;
            entity.Description = film.Description;
            entity.ReleaseYear = film.ReleaseYear;

            _context.SaveChanges();
        }

        return entity;
    }
}