using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(mm => mm.Genre).ToList());
        }
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie==null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpPatch]
        public IHttpActionResult CreateMovie([FromBody]Movie movie)
        {
            if (movie==null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }
        [HttpPut]
        public IHttpActionResult UpdateMovie([FromUri]int id, [FromBody]Movie movie)
        {
            var dbMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (dbMovie == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            dbMovie.Name = movie.Name;
            dbMovie.ReleaseDate = movie.ReleaseDate;
            dbMovie.NumberAvailable = movie.NumberAvailable;
            dbMovie.NumberInStock = movie.NumberInStock;
            dbMovie.GenreId = movie.GenreId;
            _context.SaveChanges();
            return Ok();

        }

        public IHttpActionResult DeleteMovie(int id)
        {
            var dbMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (dbMovie == null)
            {
                return BadRequest();
            }
            _context.Movies.Remove(dbMovie);
            _context.SaveChanges();
            return Ok();
        }


    }
}
