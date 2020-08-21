using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }



        // Get: Finish Registration
        public IActionResult FinishRegistration()
        {
            Employee employee = new Employee();
            employee.EmailAddress = this.User.FindFirstValue(ClaimTypes.Name);

            return View(employee);
        }

        // POST: Finish Registering
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FinishRegistration(Employee employee)
        {
            try
            {
                employee.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.EmailAddress = this.User.FindFirstValue(ClaimTypes.Name);

                _context.Add(employee);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("FinishRegistration");
            }

            var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.Address, c => c.WeeklyPickupDay);
            employee.Addresses = addresses;



            return View(employee);
        }


        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult TodaysPendingPickups(int id)
        {
            try
            {
                //var employee = _context.Employees.Where(e => e.Id == id).Single();

                ViewBag.ListFor = "Today's Pending One-Time Pickups";

                //var pickups = _context.OneTimePickups.Include(p => p.Customer).Where(c => c.Customer.SpecialtyPickupDay.Date == DateTime.Today).Where(p => p.EmployeeId == id).Include(p=> p.Employee);
                var pickups = _context.OneTimePickups.Include(c => c.Customer);
                var filterCustomer = pickups.Where(c=> c.PickUpDate.Day == DateTime.Today.Day ).Include(e => e.Employee).AsQueryable();
                var filterEmployee = filterCustomer.Where(e => e.EmployeeId == id).AsEnumerable();

                return View("OneTimePickups", filterEmployee);

            }
            catch
            {
                return View();
            }
        }
        public IActionResult AllPendingPickups(int id)
        {
            try
            {
                //var employee = _context.Employees.Where(e => e.Id == id).Single();

                ViewBag.ListFor = "All Pending Pickups";

                var pickups = _context.OneTimePickups.Include(p => p.Customer).Where(p => p.EmployeeId == id).Include(p => p.Employee);


                return View("OneTimePickups", pickups);

            }
            catch
            {
                return View();
            }
        }

        public IActionResult PickupCompleted(OneTimePickup completedPickup)
        {
            try
            {
                var completedPickupInDb = _context.OneTimePickups.Find(completedPickup);

                var customer = _context.Customers.Where(c => c.Id == completedPickupInDb.CustomerId).FirstOrDefault();
                customer.SpecialtyPickupCompleted = true;


                double pickupFee = TrashPrices.GetOneTimePickupCost(customer);
                customer.OutstandingBalance += pickupFee;

                customer.SpecialtyPickupDay = DateTime.MinValue;
                completedPickup.HasBeenPickedup = true;
                _context.SaveChanges();

                var employee = _context.Employees.Where(e => e.Id == completedPickup.EmployeeId).SingleOrDefault();
                var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.Address, c => c.WeeklyPickupDay);
                employee.Addresses = addresses;
                return View("Index", employee);


            }
            catch
            {
                var employee = _context.Employees.Where(e => e.Id == completedPickup.EmployeeId).SingleOrDefault();
                var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.Address, c => c.WeeklyPickupDay);
                employee.Addresses = addresses;
                return View("Index", employee);
            }
        }


        public IActionResult AddressMap()
        {
            Customer customer = new Customer();


            return View(customer);
        }

    }
}
