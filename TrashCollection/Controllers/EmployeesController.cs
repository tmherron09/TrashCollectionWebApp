﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrashCollection.Data;
using TrashCollection.Models;
using TrashCollection.ViewModels.Employees;

namespace TrashCollection.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        private static readonly HttpClient HttpClient = new HttpClient();

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
            
        }


        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("FinishRegistration");
            }

            var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.StreetAddress, c => c.WeeklyPickupDay);
            employee.Addresses = addresses;

            return View(employee);
        }
        [HttpGet]
        public IActionResult Index(string message)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction("FinishRegistration");
            }

            employee.Addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.StreetAddress, c => c.WeeklyPickupDay);

            EmployeesIndexViewModel employeeIndexViewModel = new EmployeesIndexViewModel(employee, _context);

            return View(employeeIndexViewModel);
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

                EmployeesIndexViewModel employeeIndexViewModel = new EmployeesIndexViewModel(employee, _context, "Registration Complete");

                return View("Index", employeeIndexViewModel);
            }
            catch
            {

                return View();
            }
        }


        public IActionResult TodaysPendingPickups(int id)
        {
            try
            {
                ViewBag.ListFor = "Today's Pending One-Time Pickups";
                var pickupskWithEmployeeCustomer = _context.OneTimePickups
                    .Include(p => p.Customer);

                var todaysPickups = pickupskWithEmployeeCustomer.Where(p => p.EmployeeId == id &&
                                                                p.HasBeenPickedup == false &&
                                                                p.PickUpDate.DayOfYear == DateTime.Today.DayOfYear)
                                                                .OrderBy(p => p.PickUpDate).AsEnumerable();

                ViewData["EmployeeId"] = id;

                return View("OneTimePickups", todaysPickups);

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
                ViewBag.ListFor = "All Pending Pickups";

                var pickupskWithEmployeeCustomer = _context.OneTimePickups
                    .Include(p => p.Customer);

                //var pickups = pickupskWithEmployeeCustomer.Where(p => p.EmployeeId == id).OrderBy(p=> p.PickUpDate).ToList();
                var pickups = pickupskWithEmployeeCustomer.Where(p => p.EmployeeId == id && p.HasBeenPickedup == false).OrderBy(p => p.PickUpDate).AsEnumerable();

                ViewData["EmployeeId"] = id;

                return View("OneTimePickups", pickups);

            }
            catch
            {
                return View();
            }
        }

        public IActionResult PickupCompleted(int id)
        {

            //var completedPickupInDb = _context.OneTimePickups.Where(o => o.Id == completedPickup.Id).Single();


            var completedPickupInDb = _context.OneTimePickups.Where(o => o.Id == id).Single();

            try
            {


                //var completedPickupInDb = _context.OneTimePickups.Find(completedPickup);

                var customer = _context.Customers.Where(c => c.Id == completedPickupInDb.CustomerId).FirstOrDefault();
                customer.SpecialtyPickupCompleted = true;


                double pickupFee = TrashPrices.GetOneTimePickupCost(customer);
                customer.OutstandingBalance += pickupFee;

                AccountTransaction serviceFee = new AccountTransaction();
                serviceFee.CustomerId = customer.Id;
                serviceFee.Fee = pickupFee;
                serviceFee.TransactionDate = DateTime.Today;
                serviceFee.TransactionType = "Specialty Pickup";

                customer.SpecialtyPickupDay = DateTime.MinValue;
                completedPickupInDb.HasBeenPickedup = true;
                _context.AccountTransactions.Add(serviceFee);
                _context.SaveChanges();

                var employee = _context.Employees.Where(e => e.Id == completedPickupInDb.EmployeeId).SingleOrDefault();
                var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.StreetAddress, c => c.WeeklyPickupDay);
                employee.Addresses = addresses;

                EmployeesIndexViewModel employeesIndexView = new EmployeesIndexViewModel(employee, _context, "Pickup Confirmation Recieved.");

                //return View("Index", employeesIndexView);
                return Index("Pickup Confirmation Recieved.");

            }
            catch
            {
                //completedPickupInDb = _context.OneTimePickups.Where(o => o == (OneTimePickup)completedPickup).Single();
                var employee = _context.Employees.Where(e => e.Id == completedPickupInDb.EmployeeId).SingleOrDefault();
                var addresses = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToDictionary(c => c.StreetAddress, c => c.WeeklyPickupDay);
                employee.Addresses = addresses;

                EmployeesIndexViewModel employeesIndexView = new EmployeesIndexViewModel(employee, _context, "Pickup Confirmation Failed!");

                return View("Index", employeesIndexView);
            }
        }

        

        public async Task<IActionResult> AddressMapView(int id)
        {
            Employee employee = _context.Employees.Where(e => e.Id == id).Single();
            var customers = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToList();
            var locations = await GetMultipleCustomerLongLat(customers);

            ViewData["EmployeeId"] = employee.Id;

            return View(locations);
        }
        // Unused currently, will be brough back to utilize Google Maps static/javascript
        public async Task<Queue<LocationResponse>> GetMultipleCustomerLongLat(List<Customer> customers)
        {

            Queue<LocationResponse> locations = new Queue<LocationResponse>();

            string key = "*INSERT API KEY";

            foreach (var customer in customers)
            {
                string query = HttpUtility.UrlEncode(customer.StreetAddress + "," + customer.City + "," + customer.ZipCode);
                Uri googleMapsApiUriRequest = new Uri("https://maps.googleapis.com/maps/api/geocode/json?&address=" + query + key);

                var response = await HttpClient.GetAsync(googleMapsApiUriRequest);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                JObject jsonString = JObject.Parse(content);
                var location = JsonConvert.DeserializeObject<LocationResponse>(content);
                locations.Enqueue(location);

            }

            return locations;
        }

        public async Task<IActionResult> AddressMapViewIndividual(int id)
        {
            Customer customer= _context.Customers.Where(e => e.Id == id).Single();
            var locations = await GetSingleCustomerLongLat(customer);

            // Populate _layout_Employee, temp fix
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            ViewData["EmployeeId"] = employee.Id;
            return View(locations);
        }

        public async Task<LocationResponse> GetSingleCustomerLongLat(Customer customer)
        {
                string key = "*INSERT API KEY";
                string query = HttpUtility.UrlEncode(customer.StreetAddress + "," + customer.City + "," + customer.ZipCode);
                Uri googleMapsApiUriRequest = new Uri("https://maps.googleapis.com/maps/api/geocode/json?&address=" + query + key);

                var response = await HttpClient.GetAsync(googleMapsApiUriRequest);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                JObject jsonString = JObject.Parse(content);
                var location = JsonConvert.DeserializeObject<LocationResponse>(content);

            return location;
        }

        // Google Maps Embeded Api, No Long used, but kept for easy use/reference.
        public IActionResult AddressMap(int id)
        {
            // Removed Secret, may require API request below to be adjusted for key + query.
            string key = "*INSERT API KEY";
            Customer customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            string query;
            string googleMapsApiUrlRequest;
            //Html encode (spaces, periods, etc)
            try
            {
                //mapUrl =  await GetGoogleMapsApiUrl(customer);
                query = HttpUtility.UrlEncode(customer.StreetAddress + "," + customer.City + "," + customer.ZipCode);
                googleMapsApiUrlRequest = "https://www.google.com/maps/embed/v1/place?" + key + query;
            }
            catch
            {
                // Todo: Call error log.
                EmployeesIndexViewModel employeesIndexView = new EmployeesIndexViewModel(employee, _context, "Pickup Confirmation Failed!");

                return View("Index", employeesIndexView);
            }
            employee.Addresses = new Dictionary<string, string>();
            employee.Addresses.Add($"{customer.FamilyName} residence: {customer.StreetAddress}, {customer.City}, {customer.ZipCode}", googleMapsApiUrlRequest);
            return View(employee);
        }
    }
}
