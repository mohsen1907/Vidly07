using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly07.Models;

namespace Vidly07.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public Movie Movie { get; set; }

		public String Tittle
		{
			get
			{
				if (Movie!=null&& Movie.Id!=0)
				{
					return "Edit Movie";
				}
				return "New Movie";
			}
		}
	}
}