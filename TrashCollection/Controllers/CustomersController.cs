using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: Finish Registration
        public IActionResult FinishRegistration()
        {
            Customer customer = new Customer();
            customer.EmailAddress = this.User.FindFirstValue(ClaimTypes.Name);

            return View(customer);
        }

        // POST: Finish Registering
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FinishRegistration(Customer customer)
        {
            try
            {
                customer.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.EmailAddress = this.User.FindFirstValue(ClaimTypes.Name);

                _context.Add(customer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("FinishRegistration");
            }

            return View(customer);
        }
        [HttpGet]
        public ActionResult Index(string message)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("FinishRegistration");
            }


            return View(customer);
        }
        

        // GET: CustomersController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public IActionResult ChangePickUpDay(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);

            return View(customer);
        }


        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePickUpDay(Customer customer)
        {

            Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.WeeklyPickupDay = customer.WeeklyPickupDay;
            _context.SaveChanges();
            
            //return View( "Index", customerInDb);
            return RedirectToAction(nameof(Index), new { message = "Weekly Trash day has been succesfully changed." });
        }

        public IActionResult SpecialtyPickup(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);

            return View(customer);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SpecialtyPickup(Customer customer)
        {
            // Set the pickup Date for customer.
            Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDb.SpecialtyPickupDay = customer.SpecialtyPickupDay;
            customerInDb.SpecialtyPickupCompleted = false;

            // Start an entry on the OneTimePickup Table
            OneTimePickup specialtyPickup = new OneTimePickup();
            specialtyPickup.PickUpDate = customerInDb.SpecialtyPickupDay;
            specialtyPickup.HasBeenPickedup = false;

            // Assign customer to entry
            specialtyPickup.CustomerId = customerInDb.Id;
            customerInDb.SpecialtyPickupCompleted = false;

            // Assign Employee with matching ZipCode.
            // Error Handling: FirstOrDefault due to seeding and Zipcode note currently set to Unique.
            var employeeId = _context.Employees.Where(e => e.AssignedZipCode == customerInDb.ZipCode).Select(e => e.Id).FirstOrDefault();
            specialtyPickup.EmployeeId = employeeId;

            _context.OneTimePickups.Add(specialtyPickup);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
