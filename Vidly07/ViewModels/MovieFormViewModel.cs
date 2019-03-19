using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly07.Models;

namespace Vidly07.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public Movie Movie { get; set; }

        public int Id { get; set; }

        [Required]
		[StringLength(255)]
		public string Name { get; set; }


		[Required]
		[Display(Name = "Genre")]
		public Byte? GenreId { get; set; }

		[Display (Name = "Release Date")]
        [Required]
		public DateTime? RelaseDate { get; set; }

	   
		[Display(Name = "Number In Stock")]
		[Range(1,20)]
		public Byte NumberInStock { get; set; }

        public String Tittle
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            RelaseDate = movie.RelaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}