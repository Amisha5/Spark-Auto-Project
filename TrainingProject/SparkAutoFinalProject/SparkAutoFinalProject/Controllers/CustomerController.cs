using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Spark.DataLayer;
using Spark.DataModel.Models;
using SparkAutoFinalProject.ApiControllers;
using SparkAutoFinalProject.Data;
using SparkAutoFinalProject.Models;
using SparkAutoFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly SparkDbContext _sparkDbContext;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration1;
        string apiUrl1;
        public CustomerController(ILogger<CustomerController> logger,IConfiguration configuration ,ICustomerRepository customerRepository,SparkDbContext sparkDbContext,ApplicationDbContext applicationDbContext)
        {
            _customerRepository = customerRepository;
            _applicationDbContext = applicationDbContext;
            _sparkDbContext = sparkDbContext;
            _logger = logger;
            _configuration1 = configuration;
            apiUrl1 = _configuration1.GetValue<string>("WebAPIBase1Url");
        }
        [BindProperty]
        public Car Car { get; set; }
       
        [BindProperty]
        public CarServiceViewModel carServiceViewModel { get; set; }
        [Authorize]
        public IActionResult GetCustomerDetails(string search=" ")
        {
          
            List<ApplicationUser> res = _applicationDbContext.ApplicationUsers.Where(e => e.Email.Contains(search)).ToList();
           
            return View(res);

        }
        public IActionResult GetCustomerById(string id)
        {
            ViewBag.Id = id;
          
            var CarAndCustVM = new CarCustomerViewModel()
            {
                Cars = _sparkDbContext.Cars.Where(c => c.ApplicationUserId == id).ToList(),
                applicationUser = _applicationDbContext.ApplicationUsers.FirstOrDefault(u => u.Email == id)
            };
          
           
            return View(CarAndCustVM);
        }
        public async Task<IActionResult> DeleteCustomer(string id)
        {
           
            var results = new ApplicationUser();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"{apiUrl1}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
                }
            }
            return RedirectToAction("GetCustomerDetails");

        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(ApplicationUser applicationUser)
        {
            
            var resService = new ApplicationUser();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(applicationUser), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiUrl1, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resService = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
                }
            }
            return RedirectToAction("GetCustomerDetails");
        }
        
        public IActionResult EditCustomer(string id)
        {
            
            var custEdit = _applicationDbContext.ApplicationUsers.Where(e => e.Id == id).FirstOrDefault();
                return View(custEdit);
        }
        [HttpPost]
        public IActionResult EditCustomer(string id,ApplicationUser app)
        {

            var editCust = _applicationDbContext.ApplicationUsers.Where(e => e.Id == app.Id).FirstOrDefault();
            editCust.Name = app.Name;
            editCust.Email = app.Email;
            editCust.PhoneNumber = app.PhoneNumber;
            editCust.City = app.City;
            editCust.Address = app.Address;
            editCust.PostalCode = app.PostalCode;
            editCust.Role = app.Role;
            _applicationDbContext.SaveChanges();
            return RedirectToAction("GetCustomerDetails", new { id = Car.ApplicationUserId });
        
          
            
        }

        public IActionResult CreateCarDetails(string id)
        {
            ViewBag.Id = id;
            string Id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCarDetails(string id,Car car)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateCarDetails");
            }
            else
            {
                ViewBag.Id = id;
               
                var insertCar = _sparkDbContext.Cars.Add(car);
                _sparkDbContext.SaveChanges();

                if (User.Identity.Name == "amisha@gmail.com")
                {
                    return RedirectToAction("GetCustomerById", "Customer", routeValues: new { id = car.ApplicationUserId });

                }
                else
                {
                    return RedirectToAction("CustomerPage", "User", routeValues:new { id = Car.ApplicationUserId });
                }
               
            }
         }

        public IActionResult GetServiceHistory(string Id,int carId)
        {

            var ServiceViewModel = new CarServiceViewModel
            {
                ServiceHistory = _sparkDbContext.CarServiceHistories.Include(c => c.Car).Where(c => c.CarId == carId).ToList(),
                ApplicationUsers = _applicationDbContext.ApplicationUsers.Where(e => e.Email == Id).FirstOrDefault(),
                Cart = _sparkDbContext.ServiceShoppingCarts.Include(s => s.ServiceType).Include(c => c.Car).Where(c => c.CarId == carId).ToList(),
                ServiceTypes = _sparkDbContext.CarServiceTypes.ToList(),
                Car = _sparkDbContext.Cars.Where(c => c.CarId == carId).FirstOrDefault(),
                ServiceHistoryyy = _sparkDbContext.CarServiceHistories.Include(c => c.Car).Where(c => c.CarId == carId).FirstOrDefault(),

            };
            return View(ServiceViewModel);
          
        }
        public IActionResult GetServiceHistoryDetails(string Id,int sId,int cId)
        {
            ViewBag.Name = User.Identity.Name;
            var ServiceDetails = new CarServiceViewModel
            {
                ServiceHistory = _sparkDbContext.CarServiceHistories.Include(c => c.Car).Where(c=>c.Id==sId).ToList(),
                ApplicationUsers = _applicationDbContext.ApplicationUsers.Where(x=>x.Email==Id).FirstOrDefault(),
                ServiceDetails = _sparkDbContext.CarServiceDetails.Include(c=>c.ServiceType).Where(e=>e.ServiceHistoryId==sId).ToList(),
                Cart = _sparkDbContext.ServiceShoppingCarts.Include(s => s.ServiceType).Include(c => c.Car).Where(c => c.CarId == cId).ToList()

            };
            return View(ServiceDetails);
        }

        
        public IActionResult CreateNewService(int sId,string Id,ServiceShoppingCart serviceShoppingCart)
        {
            ViewBag.Service = _sparkDbContext.CarServiceTypes.ToList();
            var NewService = new CarServiceViewModel
            {
                Car = _sparkDbContext.Cars.Where(c => c.CarId == sId).FirstOrDefault(),
                ServiceHistory = _sparkDbContext.CarServiceHistories.Include(c => c.Car).ToList(),
                ApplicationUsers = _applicationDbContext.ApplicationUsers.Where(c => c.Email == Id).FirstOrDefault(),
                ServiceTypes = _sparkDbContext.CarServiceTypes.ToList(),
                Cart = _sparkDbContext.ServiceShoppingCarts.Include(s => s.ServiceType).Include(c => c.Car).Where(c => c.CarId == sId).ToList(),
                ServiceHistoryyy = _sparkDbContext.CarServiceHistories.Include(c => c.Car).FirstOrDefault()

             };
           
            return View(NewService);
           
        }
        
        public IActionResult ServiceSummary(string Id, int carId,ServiceShoppingCart shop)
        {
            
            string nameId = Id;
            _sparkDbContext.ServiceShoppingCarts.Add(shop);
            _sparkDbContext.SaveChanges();
           
            return RedirectToAction("CreateNewService", new {  sId=carId, id = nameId});
        }
        public IActionResult ServiceComplete(string Id, int Carid, CarServiceHistory detail)
        {
             string nameId = Id;
            _sparkDbContext.CarServiceHistories.Add(detail);
            _sparkDbContext.SaveChanges();
            
            return RedirectToAction("GetCustomerById", new {id = nameId});
        }
        public IActionResult DeleteNewService(int shopId, string Id, int carId)
        {
            string nameId = Id;
            var serviceDel = _sparkDbContext.ServiceShoppingCarts.Where(e => e.Id == shopId).FirstOrDefault();
            _sparkDbContext.ServiceShoppingCarts.Remove(serviceDel);
            _sparkDbContext.SaveChanges();
            return RedirectToAction("CreateNewService", new { sId = carId, id =nameId });
        }
        public IActionResult DeleteCar(int id)
        {

            Car = _sparkDbContext.Cars.Where(e => e.CarId == id).FirstOrDefault();
            var UserId = Car.ApplicationUserId;
            _sparkDbContext.Cars.Remove(Car);
            _sparkDbContext.SaveChanges();

            if (User.Identity.Name == "amisha@gmail.com")
            {
                return RedirectToAction("GetCustomerById", new { id = Car.ApplicationUserId });
            }
            else
            {
                return RedirectToAction("CustomerPage", "User", new { id = Car.ApplicationUserId });
            }
        }

        public IActionResult EditCarDetails(int id)
        {
            var editCar = _sparkDbContext.Cars.FirstOrDefault(s => s.CarId == id);
            return View(editCar);

          
        }
        [HttpPost]
        public IActionResult EditCarDetails(Car car)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditCarDetails");
            }
            else
            {
                var editCar = _sparkDbContext.Cars.Where(e => e.CarId == car.CarId).FirstOrDefault();

                editCar.VIN = car.VIN;
                editCar.Model = car.Model;
                editCar.Miles = car.Miles;
                editCar.Make = car.Make;
                editCar.Style = car.Style;
                editCar.YearCount = car.YearCount;
                editCar.CarColor = car.CarColor;
                _sparkDbContext.SaveChanges();
                
                if (User.Identity.Name == "amisha@gmail.com")
                {
                    return RedirectToAction("GetCustomerById", new { id = Car.ApplicationUserId });
                }
                else
                {
                    return RedirectToAction("CustomerPage", "User", new { id = Car.ApplicationUserId });
                }
            }
        }

    }
}
