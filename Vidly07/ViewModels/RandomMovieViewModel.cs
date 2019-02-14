using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly07.Models;

namespace Vidly07.ViewModels
{
	public class RandomMovieViewModel
	{
		public Movie Movie { get; set; }
		public List<Customer> Customers { get; set; }
	}
}