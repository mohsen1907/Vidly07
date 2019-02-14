using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly07.Models;
using Vidly07.ViewModels;

namespace Vidly07.Controllers
{
    public class MoviesController : Controller
    {
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