using Spark.DataModel.Models;
using SparkAutoFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.ViewModels
{
    public class NewServiceViewModel
    {
        public Car SCar { get; set; }
        public IEnumerable<CarServiceHistory> SHistory { get; set; }
        public CarServiceDetails SDetails { get; set; }
        public ApplicationUser AUsers { get; set; }
        public IEnumerable<CarServiceType> STypes { get; set; }
       
    }
}
