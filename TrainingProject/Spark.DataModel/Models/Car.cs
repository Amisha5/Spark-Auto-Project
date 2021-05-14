using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spark.DataModel.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Enter VIN number")]
        [RegularExpression("[A-HJ-NPR-Z0-9]{13}[0-9]{4}", ErrorMessage = "Invalid Vehicle Identification Number Format.")]

        //[RegularExpression("[A-Za-z0-9]{11}[0-9]{6}", ErrorMessage = "Invalid Vehicle Identification Number Format.")]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Enter Maker name")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Enter Car Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Enter style of Car")]
        public string Style { get; set; }
        [Required(ErrorMessage = "Enter valid Year Count")]

        public int YearCount { get; set; }
        [Required(ErrorMessage = "Enter Miles")]
        public double Miles { get; set; }
        [Required(ErrorMessage = "Enter Car color")]

        public CarColor CarColor { get; set; }
        [Required(ErrorMessage ="Required field")]

        public string ApplicationUserId { get; set; }
    }
}
