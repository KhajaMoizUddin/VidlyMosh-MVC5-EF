using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMain.Models;
using VidlyMain.ViewModel;

namespace VidlyMain.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MyDbContext dbContext;

        public CustomersController()
        {
            this.dbContext = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this.dbContext.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var customerList = this.dbContext.Customers.Include(x => x.MembershipType).ToList();
            return View(customerList);
        }

        public ActionResult Details(int id)
        {
            var customerDetails = this.dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if (customerDetails == null)
                return HttpNotFound();

            var memberShipType = this.dbContext.MembershipTypes.ToList();
            var customerViewModel = new CustomerFormViewModel()
            {
                Customer = customerDetails,
                MembershipType = memberShipType
            };
            return View("CustomerForm", customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipType = this.dbContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                this.dbContext.Customers.Add(customer);

            else
            {
                var customerDetails = this.dbContext.Customers.Single(x => x.Id == customer.Id);
                customerDetails.Name = customer.Name;
                customerDetails.BirthDate = customer.BirthDate;
                customerDetails.MemberShipTypeId = customer.MemberShipTypeId;
                customerDetails.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            this.dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Delete(int id)
        {
            Customer customerById = this.dbContext.Customers.FirstOrDefault(x => x.Id == id);
             this.dbContext.Customers.Remove(customerById);
             this.dbContext.SaveChanges();
             return RedirectToAction("Index", "Customers");
        }

        public ActionResult AddCustomer()
        {
            var memberShipTypes = this.dbContext.MembershipTypes.ToList();
            var customer = new Customer();


            var customerViewModel = new CustomerFormViewModel()
            {
                MembershipType = memberShipTypes,
                Customer = customer
            };
            return View("CustomerForm", customerViewModel);
        }
    }
}