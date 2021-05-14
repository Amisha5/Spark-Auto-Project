using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparkAutoFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
       
        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            string userName = User.Identity.Name;//ViewBag.UserName;

            var oneUser = _customerRepository.GetLoginRole(userName);
            
            if (oneUser == null )
            {
                //return RedirectToAction("CustomerPage", "User");
                return View();

            }
             else if(oneUser.Role == "Admin")
            {
                return RedirectToAction("GetCustomerDetails", "Customer");
            }
             else if(User.Identity.IsAuthenticated && oneUser.Role!= "Admin")
            {
                
                return RedirectToAction("CustomerPage", "User");
            }
            else
            {
                return View();
            }
                
           
        }
        public IActionResult Carousel()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
