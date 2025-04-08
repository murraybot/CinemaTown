using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaTown.Models;
using System.Data.Entity;
using CinemaTown.ViewModels;

namespace CinemaTown.Controllers
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
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            // return View(movies);

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");

            return View("ReadOnly");

        }

        [AllowAnonymous]
        public ViewResult ReadOnly()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);

        }

        [AllowAnonymous]

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genretypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                GenreTypes = genretypes
            };

            viewModel.Movie.DateAdded = DateTime.Now;

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MovieForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }
            
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseYear = movie.ReleaseYear;
                movieInDb.InStock = movie.InStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Description = movie.Description;
                movieInDb.DateAdded = movie.DateAdded;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}