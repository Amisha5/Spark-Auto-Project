using Spark.DataModel.Models;
using SparkAutoFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.ViewModels
{
    public class CarCustomerViewModel
    {
        public ApplicationUser applicationUser { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
