using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web;
using System.Web.Mvc;
using Vidly07.Models;
using Vidly07.ViewModels;

namespace Vidly07.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}
	
		public ViewResult Index()
		{
			var customers = _context.Customers.Include(c => c.MembershipType ).ToList();

			return View(customers);
		}

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}
		public ActionResult New()
		{//Send to CustomerForm ViewModel
			var membershiptypes = _context.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel()
			{
				Customer =new Customer(), 
				MembershipTypes = membershiptypes
			};
			return View("CustomerForm",viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{//receive from CustomerForm View

			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
				   Customer = customer,
				   MembershipTypes = _context.MembershipTypes.ToList()
			};

				return View("CustomerForm",viewModel);
			}
			if (customer.Id == 0)
			{
				_context.Customers.Add(customer);
			}
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
				 
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}

			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				Console.WriteLine(e);
				throw;
			}
			return RedirectToAction("Index","Customers");
		}

		public ActionResult Edit(int Id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
			if (customer==null)
				return HttpNotFound();
			var viewModel = new CustomerFormViewModel
			{
				//it filled the Textboxes, because i sent the customer to Model
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			return View("CustomerForm",viewModel);
		}
	}
}