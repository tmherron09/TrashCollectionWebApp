using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Input")]
        public string FirstName { get; set; }
        [Display(Name = "Family/Last Name")]
        [Required(ErrorMessage = "Family/Last Name is a Required Input")]
        public string FamilyName { get; set; }
        [NotMapped]
        public string AbbrvName { get { return FirstName + " " + FamilyName[0] + "."; } }
        [Required(ErrorMessage = "Email is a Required Input")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is a Required Input")]
        public string PhoneNumber { get; set; }




        // Change to Zone/Trash Route
        [RegularExpression(@"\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Display(Name = "Assigned 5-Digit Zip Code Area")]
        public string AssignedZipCode { get; set; }
        [NotMapped]
        public Dictionary<string, string> Addresses{ get; set; }
        

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
