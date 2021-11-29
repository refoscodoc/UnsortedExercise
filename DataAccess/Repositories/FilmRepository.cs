using System;
using System.Collections.Generic;
using NewWebAPIdotnet6.Models;
using System.Data.SqlClient;
// using System.Data.Common.DbConnection;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataAccess.Repositories
{
    public interface IFilmRepository
    {
        List<Film> GetFilms();
        Film GetFilm(int? id);
        Film AddFilm(Film film);
        Film DeleteFilm(int id);
        Film UpdateFilm(Film film);
    }

    public class FilmRepository : RepositoryBase, IFilmRepository
    {
        public FilmRepository() : base ("server=localhost;userid=alberto;password=vinazza;database=sakila;")
        {
            
        }
        public List<Film> GetFilms()
        {
            using (var connection = Connection())
            {
                return connection.Query<Film>(@"SELECT film_id, title, description, release_year FROM film").ToList();
            } 
        }

        public Film GetFilm(int? id)
        {
            using (var connection = Connection())
            {
                return connection.QueryFirstOrDefault<Film>($"SELECT film_id, title, description, release_year FROM film WHERE film_id = {id}");
            }
        }

        public Film AddFilm(Film film)
        {
            using (var connection = Connection())
            {
                return connection.QueryFirstOrDefault<Film>($"INSERT INTO film (film_id, title, description, release_year, language_id) VALUES (LAST_INSERT_ID() , '{film.Title}', '{film.Description}', '{film.ReleaseYear}', 1)");
            }
        }

        public Film DeleteFilm(int id)
        {
            using (var connection = Connection())
            {
                return connection.QueryFirstOrDefault<Film>($"DELETE FROM film WHERE film_id = {id}");
            }
        }

        public Film UpdateFilm(Film film)
        {
            using (var connection = Connection())
            {
                return connection.QueryFirstOrDefault<Film>($"UPDATE film SET title = '{film.Title}', description = '{film.Description}', release_year = {film.ReleaseYear} WHERE film_id = {film.FilmId}");
            }
        }
    }
}

