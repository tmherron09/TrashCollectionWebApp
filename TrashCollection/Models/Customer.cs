using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class Customer
    {

        public Customer()
        {
            OutstandingBalance = 0.00;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public int PhoneNumber { get; set; }


        public string WeeklyPickupDay { get; set; }
        public bool SpecialtyPickupCompleted { get; set; }




        public double OutstandingBalance { get; set; }


        public string StartDate { get; set; }
        public string EndDate { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string ZipCode { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }
}
