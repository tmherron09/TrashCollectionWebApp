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

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }


        public string WeeklyPickupDay { get; set; }
        public bool SpecialtyPickupPending { get; set; }




        public double OutstandingBalance { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }


        public string Address { get; set; }
        public string ZipCode { get; set; }




    }
}
