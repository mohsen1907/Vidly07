﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly07.Models;
using Vidly07.ViewModels;

namespace Vidly07.Controllers
{
    public class MoviesController : Controller
    {
	    private ApplicationDbContext _context;

	    public MoviesController()
	    {
		    _context=new ApplicationDbContext();
	    }
	    protected override void Dispose(bool diposing)
	    {
			_context.Dispose();
	    }
		public ViewResult Index()
	    {
		    var movies = _context.Movies.Include(m=>m.Genre).ToList();

		    return View(movies);
	    }

		public ActionResult Details(int Id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==Id);
			return View(movie);
		}
		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var ViewModel = new MovieFormViewModel
			{
				Genres = genres
			};
			return View("MovieForm",ViewModel);
		}
		[HttpPost]
		public ActionResult save(Movie movie)
		{
			if (movie.Id==0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				MovieInDb.Name = movie.Name;
				MovieInDb.GenreId = movie.GenreId;
				MovieInDb.RelaseDate = movie.RelaseDate;
				MovieInDb.NumberInStock= movie.NumberInStock;
			}

			_context.SaveChanges();


			return RedirectToAction("Index","Movies");
		}

		public ActionResult Edit(int Id)
		{
			var movie = _context.Movies.SingleOrDefault(m=>m.Id==Id);
			if (movie==null)
			{
				return HttpNotFound();
			}

			var viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = _context.Genres.ToList()
			};
			return View("MovieForm",viewModel);
		}

		// GET: Movies
		public ActionResult Random()
        {
	        var movie = new Movie() {Name = "shrek" };
			var customers = new List<Customer>
			{
				new Customer{Name = "Customer 1"},
				new Customer{Name = "Customer 2"}
			};

	        var viewModel = new RandomMovieViewModel
	        {
				Movie = movie,
				Customers = customers
	        };
            return View(viewModel);
        }
    }
}