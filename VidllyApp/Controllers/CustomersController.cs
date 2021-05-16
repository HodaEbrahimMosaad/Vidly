using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidllyApp.Models;
using System.Data.Entity;
using VidllyApp.ViewModels;

//using Microsoft.EntityFrameworkCore;

namespace VidllyApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //return View(/*customers*/);

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            NewCustomerViewModel vm = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View(vm);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var vm = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("Create", vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public  ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var vm = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("Create",vm);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var oldCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                oldCustomer.Name = customer.Name;
                oldCustomer.Birthdate = customer.Birthdate;
                oldCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                oldCustomer.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
       
    }
}