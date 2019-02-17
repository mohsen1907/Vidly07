using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly07.Models;

namespace Vidly07.ViewModels
{
	public class CustomerFormViewModel
	{
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		public Customer Customer { get; set; }
	}
}