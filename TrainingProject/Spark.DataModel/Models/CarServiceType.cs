using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spark.DataModel.Models
{
    public class CarServiceType
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter valid service name")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage ="Name only contains Alphabates" )]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
