using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spark.DataModel.Models
{
    public class CarServiceHistory
    {
        public int Id { get; set; }
        [Required]
        public double Miles { get; set; }
        [Required]
        public double TotalPrice { get; set; }

        public string Details { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
