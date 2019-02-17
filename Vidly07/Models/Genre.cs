using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly07.Models
{
	public class Genre
	{
		public Byte Id { get; set; }
		[Required]
		[StringLength(254)]
		public String Name { get; set; }
	}
}