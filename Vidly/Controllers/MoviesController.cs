using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {

            var movieslist = _context.Movies.Include(mo => mo.Genre).ToList();
            return View(movieslist);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                
                Genres = genres
            };
            return View(viewModel);
        }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Save(Movie mov)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(mov)
                {
                    Genres = _context.Genres.ToList(),
                 

                };
                return View("New", viewModel);
            }
            if (mov.Id == 0)
            {
                mov.DateAdded = DateTime.Now;
                _context.Movies.Add(mov);
            }
            else
            {
                var Oldmov = _context.Movies.SingleOrDefault(mo => mo.Id == mov.Id);
                Oldmov.Name = mov.Name;
                Oldmov.GenreId = mov.GenreId;
                Oldmov.NumberAvailable = mov.NumberInStock;
                Oldmov.NumberInStock = mov.NumberInStock;
                Oldmov.ReleaseDate = mov.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var selectedMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (selectedMovie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(selectedMovie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("New",viewModel);
        }

    }
}
