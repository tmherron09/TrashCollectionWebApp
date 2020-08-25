using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollection.Models;

namespace TrashCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OneTimePickup> OneTimePickups { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                     new IdentityRole
                    {
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE"
                    }, new IdentityRole
                    {
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    }
                );

            builder.Entity<Employee>()
                .HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Default Employee",
                    FamilyName = "Fail Case",
                    EmailAddress = "default@trash.com",
                    PhoneNumber = "555-555-5555",
                    AssignedZipCode = "00000"
                }
                );
        }

        
    }
}
