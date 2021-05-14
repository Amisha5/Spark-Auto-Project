using Spark.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Models
{
    public interface ICustomerRepository
    {
        ApplicationUser GetLoginRole(string UserName);
        IEnumerable<ApplicationUser> GetCustomerDetail();

        //ApplicationUser GetCustomerById(string appId);

        ApplicationUser DeleteCustomers(string appId);
        ApplicationUser InsertCustomers(ApplicationUser applicationUser);
        ApplicationUser EditCustomer(string id, ApplicationUser applicationUser);
        //ApplicationUser InsertCar(ApplicationUser appId);


    }
}
