using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMain.Models;
using VidlyMain.ViewModel;

namespace VidlyMain.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext _dbContext;

        public MoviesController()
        {
            this._dbContext = new MyDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movieList = this._dbContext.Movies.Include(x => x.Genre).ToList();
            return View(movieList);
        }

        public ActionResult Details(int id)
        {
            var movies = this._dbContext.Movies.FirstOrDefault(x => x.Id == id);
            var genre = this._dbContext.Genres.ToList();

            var moviesViewModel = new MoviesViewModel()
            {
                Genres = genre,
                Movies = movies

            };

            return View("MoviesForm", moviesViewModel);
        }

        public ActionResult Delete(int id)
        {
            var deleteMovie = this._dbContext.Movies.SingleOrDefault(x => x.Id == id);
            this._dbContext.Movies.Remove(deleteMovie);
            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovies(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                var moviesViewModel = new MoviesViewModel()
                {
                    Movies = movies,
                    Genres = this._dbContext.Genres.ToList()
                };
                return View("MoviesForm", moviesViewModel);
            }

            if (movies.Id == 0)
                this._dbContext.Movies.Add(movies);

            else
            {
                var movieUpdate = this._dbContext.Movies.SingleOrDefault(x => x.Id == movies.Id);
                movieUpdate.Name = movies.Name;
                movieUpdate.ReleaseDate = movies.ReleaseDate;
                movieUpdate.NumberInStock = movies.NumberInStock;
                movieUpdate.GenreId = movies.GenreId;
            }
            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");


        }

        public ActionResult Create()
        {
            var genres = this._dbContext.Genres.ToList();

            var moviesViewModel = new MoviesViewModel()
            {
                Genres = genres
            };
            return View("MoviesForm",moviesViewModel);
        }
    }
}