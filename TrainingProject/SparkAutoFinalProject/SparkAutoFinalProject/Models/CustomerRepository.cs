using Spark.DataLayer;
using Spark.DataModel.Models;
using SparkAutoFinalProject.Data;
using SparkAutoFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SparkDbContext _sparkDbContext;
        private readonly ApplicationDbContext _applicationDbContext;
       

        public CustomerRepository( ApplicationDbContext applicationDbContext,SparkDbContext sparkDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _sparkDbContext = sparkDbContext;
           
        }
        //public ApplicationUser GetCustomerById(string appId)
        //{
        //    //var CarAndCustVM = new CarCustomerViewModel()
        //    //{
        //    //    Cars = _sparkDbContext.Cars.Where(c => c.ApplicationUserId == appId).ToList(),
        //    //    applicationUser = _applicationDbContext.ApplicationUsers.FirstOrDefault(u => u.Id == appId)
        //    //};
        //    ////var result = _applicationDbContext.ApplicationUsers.Where(e => e.Id == appId).FirstOrDefault();
        //    //return CarAndCustVM;
        //}

        public IEnumerable<ApplicationUser> GetCustomerDetail()
        {
            var res = _applicationDbContext.ApplicationUsers.ToList();
            return res;
        }

        public ApplicationUser GetLoginRole(string uName)
        {
            var resUser = _applicationDbContext.ApplicationUsers.Where(e => e.UserName == uName).FirstOrDefault();
            return resUser;
        }
        public ApplicationUser DeleteCustomers(string appId)
        {
            var deleteCust = _applicationDbContext.ApplicationUsers.Where(e => e.Id == appId).FirstOrDefault();
            _applicationDbContext.ApplicationUsers.Remove(deleteCust);
            _applicationDbContext.SaveChanges();
            return deleteCust;
        }

        public ApplicationUser EditCustomer(string id, ApplicationUser applicationUser)
        {
            var editCust = _applicationDbContext.ApplicationUsers.Where(e => e.UserName == applicationUser.UserName).FirstOrDefault();
            editCust.Name = applicationUser.Name;
            editCust.Email = applicationUser.Email;
            editCust.PhoneNumber = applicationUser.PhoneNumber;
            editCust.City = applicationUser.City;
            editCust.Address = applicationUser.Address;
            editCust.PostalCode = applicationUser.PostalCode;
            editCust.Role = applicationUser.Role;
            _applicationDbContext.SaveChanges();
            return editCust;
        }
        public ApplicationUser InsertCustomers(ApplicationUser applicationUser)
        {
            var insertCust = _applicationDbContext.ApplicationUsers.Add(applicationUser);
           _applicationDbContext.SaveChanges();
            return applicationUser;
        }

        //public Car InsertCar(Car carId)
        //{
        //    var insertCar = _customerRepository.Cars.Add(carId);
        //    _sparkDbContext.SaveChanges();
        //    return insertCar;
        //}
    }
}