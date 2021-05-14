using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spark.DataModel.Models
{
    public class CarServiceDetails
    {
        public int Id { get; set; }
        public int ServiceHistoryId { get; set; }
        [ForeignKey("ServiceHistoryId")]
        public virtual CarServiceHistory CarServiceHistory { get; set; }

        public int ServiceTypeId { get; set; }
        [ForeignKey("ServiceTypeId")]
        public virtual CarServiceType ServiceType { get; set; }

        public string ServiceName { get; set; }
        public double ServicePrice { get; set; }
    }
}
