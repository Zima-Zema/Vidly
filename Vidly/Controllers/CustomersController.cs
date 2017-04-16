using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        //private VidlyModel db = new VidlyModel();

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(cu => cu.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var membership = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer=new Customer(),
                MembershipTypes = membership
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewCustomerViewModel NewCus)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = NewCus.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("New", viewModel);
            }

            if (NewCus.Customer.Id==0)
            {
                _context.Customers.Add(NewCus.Customer);
            }
            else
            {
                var OldCus = _context.Customers.SingleOrDefault(CC => CC.Id == NewCus.Customer.Id);
                //TryUpdateModel(OldCus);
                OldCus.Name = NewCus.Customer.Name;
                OldCus.Brithdate = NewCus.Customer.Brithdate;
                OldCus.IsSubscribedToNewsletter = NewCus.Customer.IsSubscribedToNewsletter;
                OldCus.MembershipTypeId = NewCus.Customer.MembershipTypeId;


            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var newcus = _context.Customers.SingleOrDefault(cu => cu.Id == id);
            if (newcus == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = newcus,
                MembershipTypes=_context.MembershipTypes.ToList()
            };
            return View("New",viewModel);
        }


    }
}
