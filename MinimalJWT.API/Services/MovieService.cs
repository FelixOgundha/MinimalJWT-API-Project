using DataAccess.Data;
using DataAccess.Entities;
using MinimalJWT.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace MinimalJWT.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Movie Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        public bool Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is null) return false;
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return true;
        }

        public Movie Get(int id)
        {
            var movie = _context.Movies.FirstOrDefault(o => o.Id == id);

            if (movie == null) return null;

            return movie;
        }

        public List<Movie> List()
        {
           var movies =_context.Movies.ToList();

            return movies;
        }

        public Movie Update(MovieModel movie)
        {
            var currentMovie = _context.Movies.FirstOrDefault(o => o.Id == movie.Id);

            if (currentMovie is null) return null;

            currentMovie.Title = movie.Title;
            currentMovie.Description = movie.Description;
            currentMovie.Rating = movie.Rating;

            _context.SaveChanges();
            return currentMovie;
        }
    }
}
