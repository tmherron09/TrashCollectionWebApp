using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c=> c.Address, c=> c.WeeklyPickupDay);
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

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
