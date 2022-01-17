using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VideoRentingStore.Models;
using VideoRentingStore.ViewModels;


namespace VideoRentingStore.Controllers
{  
    public class MoviesController : Controller
    {
        private  ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if(User.IsInRole(RoleName.CanManageMovies))
                return View(movies);

            return View("ReadOnlyList", movies);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null || id < 1)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var viewModel = new MovieFormViewModel { Genres = _context.Genres.ToList() };
            return View("MoviesForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel { Movie = movie, Genres = _context.Genres.ToList() };
                return View("MoviesForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.AvailableCount = movie.Stock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToEdit = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieToEdit.Name = movie.Name;
                movieToEdit.ReleaseDate = movie.ReleaseDate;
                movieToEdit.Stock = movie.Stock;
                movieToEdit.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel { Movie = movie , Genres = _context.Genres};
            
            return View("MoviesForm", viewModel);
        }



        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer1"},
        //        new Customer { Name = "Customer2"}
        //    };

        //    var viewModel = new RandomMovieViewModel 
        //    { 
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}


        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}


        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, byte month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}