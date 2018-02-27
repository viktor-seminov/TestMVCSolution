using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestMVCSolution.Models;
using System.Data.Entity;
using TestMVCSolution.ViewModels;

namespace TestMVCSolution.Controllers
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
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembeshipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var member = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = member
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customers customers)
        {
            if (customers.Id == 0)
                _context.Customers.Add(customers);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);

                customerInDb.CustomerName = customers.CustomerName;
                customerInDb.BirthDate= customers.BirthDate;
                customerInDb.MembeshipTypeId = customers.MembeshipTypeId;
                customerInDb.IsSubscibedToNewsLetter = customers.IsSubscibedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customers == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customers = customers,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}