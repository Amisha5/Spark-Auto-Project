using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparkAutoFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Authorize]
        public IActionResult GetCustomerDetails()
        {
            //var car = new List<ApplicationUser>();
            //using (HttpClient client = new HttpClient())
            //{
            //    using(var response = client.)
            //    {

            //    }
            //}
            //ViewBag.Search = search;
            //List<ApplicationUser> res = _customerRepository.ApplicationUsers.Where(e => e.Email.Contains(search)).ToList();
            var res = _customerRepository.GetCustomerDetail();
            return Ok(res);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            var resDelete = _customerRepository.DeleteCustomers(id);
            return Ok(resDelete);
        }

        
        [HttpPost]
        public IActionResult CreateCustomer(ApplicationUser applicationUser)
        {
            var insertCust = _customerRepository.InsertCustomers(applicationUser);
            return Ok(insertCust);
        }
       
        [HttpPut("{id}")]
        public IActionResult EditCustomer(string id, ApplicationUser applicationUser)
        {
            var editCust = _customerRepository.EditCustomer(id, applicationUser);
            return Ok(editCust);
        }
       

       
    }
}
