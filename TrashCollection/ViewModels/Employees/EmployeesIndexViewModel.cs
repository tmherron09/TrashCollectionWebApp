using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.ViewModels.Employees
{
    public class EmployeesIndexViewModel
    {
        public Employee Employee { get; set; }

        public List<Customer> CustomersForPickups { get; set; }

        public string Message { get; set; }

        public int TodaysPendingPickupsCount { get; set; }
        public int AllPendingPickupsCount { get; set; }

        ///////////////////////////////////////////

        public EmployeesIndexViewModel(Employee employee, ApplicationDbContext _context)
        {
            Employee = employee;

            CustomersForPickups = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToList();

            TodaysPendingPickupsCount = _context.OneTimePickups.Where(p => p.EmployeeId == employee.Id &&
                                                            p.HasBeenPickedup == false &&
                                                            p.PickUpDate.DayOfYear == DateTime.Today.DayOfYear)
                                                            .Count();
            AllPendingPickupsCount = _context.OneTimePickups.Where(p => p.EmployeeId == employee.Id &&
                                                            p.HasBeenPickedup == false)
                                                            .Count();
            Message = null;
        }

        public EmployeesIndexViewModel(Employee employee, ApplicationDbContext _context, string message)
        {
            Employee = employee;

            CustomersForPickups = _context.Customers.Where(c => c.ZipCode == employee.AssignedZipCode).ToList();

            TodaysPendingPickupsCount = _context.OneTimePickups.Where(p => p.EmployeeId == employee.Id &&
                                                            p.HasBeenPickedup == false &&
                                                            p.PickUpDate.DayOfYear == DateTime.Today.DayOfYear)
                                                            .Count();
            AllPendingPickupsCount = _context.OneTimePickups.Where(p => p.EmployeeId == employee.Id &&
                                                            p.HasBeenPickedup == false)
                                                            .Count();
            Message = message;
        }



    }
}
