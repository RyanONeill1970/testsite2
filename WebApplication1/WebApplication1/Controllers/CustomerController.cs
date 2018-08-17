using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers;
using WebApplication1.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult AllCustomers()
        {

            var AllCustomers = _context.GetCustomers.Include(c => c.MembershipType).ToList();

            var customerViewModel = new CustomerViewModel
            {
                Customers = AllCustomers

            };

            return View(customerViewModel);
        }


        public ActionResult NewCustomer() {

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFromViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)

        {

            var customer = _context.GetCustomers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null) {

                return HttpNotFound();
            }

            var viewModel = new CustomerFromViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

                return View("CustomerForm", viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFromViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                if (customer.CustomerId == 0)
                {
                    return View("NewCustomer", viewModel);
                }
                else {
                    return View("CustomerForm", viewModel);
                }
            } 



            if (customer.CustomerId == 0)
            {
                _context.GetCustomers.Add(customer);
            }
            else
            {
                var customerInDb = _context.GetCustomers.Single(c => c.CustomerId == customer.CustomerId);

                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }

           
                _context.SaveChanges();
            

            return RedirectToAction("AllCustomers", "Customer");
        }


        [Route("~/Customer/Customer-Details-{i}")]
        public ActionResult CustomerDetails(string i)
        {

            var Customer = _context.GetCustomers.SingleOrDefault(c => c.CustomerName == i);

            return View(Customer);
        }

        private dbgeneration _context;

        public CustomerController()
        {
            _context = new dbgeneration();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}