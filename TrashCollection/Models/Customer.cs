﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            OutstandingBalance = TrashPrices.MonthlyFee;
            HasServiceStop = false;
            SpecialtyPickupCompleted = false;
            SpecialtyPickupDay = DateTime.MinValue;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            
        }

        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Input")]
        public string FirstName { get; set; }
        [Display(Name = "Family/Last Name")]
        [Required(ErrorMessage = "Family/Last Name is a Required Input")]
        public string FamilyName { get; set; }
        [NotMapped]
        public string AbbrvName { get { return FirstName != null ? FirstName + " " + FamilyName[0] + ".": "unknown"; } }
        [Required(ErrorMessage = "Email is a Required Input")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is a Required Input")]
        public string PhoneNumber { get; set; }


        public string WeeklyPickupDay { get; set; }



        
        public bool? SpecialtyPickupCompleted { get; set; }

        public DateTime SpecialtyPickupDay { get; set; }
        [NotMapped]
        public ICollection<OneTimePickup> AllSpecialtyPickups { get; set; }



        public double OutstandingBalance { get; set; }
        [NotMapped]
        [Display(Name = "Current Balance")]
        public string CurrentBalance
        {
            get
            {
                return OutstandingBalance.ToString("C");
            }
        }
        [Display(Name = "Start of Service Pause")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End of Service Pause")]
        public DateTime EndDate { get; set; }
        [NotMapped]
        public bool HasServiceStop
        {
            get
            {
                if (StartDate == DateTime.MinValue && EndDate == DateTime.MinValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                return;
            }
        }

        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Display(Name = "5-Digit Zip Code")]
        public string ZipCode { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }
}
