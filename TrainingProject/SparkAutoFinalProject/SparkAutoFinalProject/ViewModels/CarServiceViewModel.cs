using Spark.DataModel.Models;
using SparkAutoFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.ViewModels
{
    public class CarServiceViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Car> Carrr { get; set; }
        public IEnumerable<CarServiceHistory> ServiceHistory { get; set; }
        public IEnumerable<CarServiceDetails> ServiceDetails { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        public IEnumerable<CarServiceType> ServiceTypes { get; set; }
        public CarServiceDetails Details { get; set; }
        public CarServiceHistory ServiceHistoryyy { get; set; }
        public  IEnumerable<ServiceShoppingCart> Cart { get; set; }
        public ServiceShoppingCart ServiceShoppingCart { get; set; }
        public CarServiceType ServiceTypesss { get; set; }

    }
}
