using Microsoft.AspNetCore.Mvc;
using Spark.DataLayer;
using SparkAutoFinalProject.Data;
using SparkAutoFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Controllers
{
    public class UserController : Controller
    {
        SparkDbContext _sparkDbContext;
        ApplicationDbContext _applicationDbcontext;
        public UserController(SparkDbContext sparkDbContext,ApplicationDbContext applicationDbContext)
        {
            _sparkDbContext = sparkDbContext;
            _applicationDbcontext = applicationDbContext;
        }
        public IActionResult CustomerPage()
        {
            string name = User.Identity.Name;
            var CarAndCustVM = new CarCustomerViewModel()
            {
                Cars = _sparkDbContext.Cars.Where(c=>c.ApplicationUserId==name).ToList(),
                applicationUser = _applicationDbcontext.ApplicationUsers.FirstOrDefault(u => u.UserName == name)
            };
            return View(CarAndCustVM);
           
        }
    }
}
