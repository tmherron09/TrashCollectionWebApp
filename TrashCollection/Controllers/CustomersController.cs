using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            customer.IdentityUserId = userId;






            return View();
        }

        // POST: Finish Registering
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FinishRegistration(IFormCollection collection)
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

        // GET: CustomersController
        public ActionResult Index()
        {

            return View();
        }

        // GET: CustomersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
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
        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult AddAccountDetails()
        {
            return View();
        }


        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomersController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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
