using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Vidly07.Models
{
	public class Movie
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public Genre Genre { get; set; }
		public Byte GenreId { get; set; }
		public DateTime RelaseDate { get; set; }
		public DateTime DateAdded { get; set; }
		public Byte NumberInStock { get; set; }
	}
}