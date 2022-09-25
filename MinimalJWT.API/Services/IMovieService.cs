using DataAccess.Entities;
using MinimalJWT.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinimalJWT.API.Services
{
    public interface IMovieService
    {
        public Movie Create(Movie movie);
        public Movie Get(int id);
        public List<Movie> List();
        public Movie Update(MovieModel movie);
        public bool Delete(int id);
    }
}
