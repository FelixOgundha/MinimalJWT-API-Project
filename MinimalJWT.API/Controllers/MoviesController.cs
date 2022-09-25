using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalJWT.API.Models;
using MinimalJWT.API.Services;
using System.Collections.Generic;

namespace MinimalJWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        [Authorize]
        public List<Movie> List()
        {
            var movies = movieService.List();

            return movies;
        }

        /*
        [HttpGet]
        public IActionResult GetMovie(int id)
        {
            var result = movieService.Get(id);
            return Ok(result);
        }
      */

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Administrator")]
        public Movie Create(Movie movie)
        {
           var result = movieService.Create(movie);
            return result;
        }
        
       [HttpPut]
       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public Movie Update(MovieModel movie)
       {
           var movies = movieService.Update(movie);
           return movies;
       }

       [HttpDelete]
       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public bool Delete(int id)
       {
           return movieService.Delete(id);
       }
        /*
       */
    }
}
