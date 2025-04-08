using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaTown.Models;
using CinemaTown.ViewModels;
using System.Data.Entity;

namespace CinemaTown.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies + ","+ RoleName.CanManageCustomers)]
        
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);

        }
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.CanManageCustomers)]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.CanManageCustomers)]
        public ViewResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            { 
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };

            return View("CustomerForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.CanManageCustomers)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.CanManageCustomers)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.street_address = customer.street_address;
                customerInDb.city_address = customer.city_address;
                customerInDb.zip_adress = customer.zip_adress;
                customerInDb.phone = customer.phone;
                customerInDb.email_address = customer.email_address;

                customerInDb.birthdate = customer.birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}