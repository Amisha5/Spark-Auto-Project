using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage = "Enter valid User Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name only contains Alphabates")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your Address")]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$", ErrorMessage = "Name valid address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter your City Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name only contains Alphabates")]

        public string City { get; set; }

        [Required(ErrorMessage ="Enter PostalCode")]
        [RegularExpression(@"^[1-9][0-9]{5}$", ErrorMessage = "PostalCode only contain 6 number and can't start with 0")]

        public int PostalCode { get; set; }
        public string Role { get; set; }
    }
}
