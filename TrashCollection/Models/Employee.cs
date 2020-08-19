using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }


        // Change to Zone/Trash Route
        public string ZipCode { get; set; }




    }
}
