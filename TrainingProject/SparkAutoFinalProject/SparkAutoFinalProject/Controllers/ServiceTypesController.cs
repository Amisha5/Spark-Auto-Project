using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Spark.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.Controllers
{
    public class ServiceTypesController : Controller
    {
        private readonly ILogger<ServiceTypesController> _logger;
        private readonly IConfiguration _configuration;
        string apiUrl;
        public ServiceTypesController(ILogger<ServiceTypesController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        //To Show whole record of CarServiceType table
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetServiceType()
        {
            var result = new List<CarServiceType>();
            using(HttpClient client = new HttpClient())
            {
                using(var response = await client.GetAsync(apiUrl))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<CarServiceType>>(apiResponse);
                }
            }
            return View(result);
        }
        public async Task<IActionResult> GetServiceTypeById(int id)
        {
            var results = new CarServiceType();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{apiUrl}/{id}"))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<CarServiceType>(apiResponse);

                    }
                    else
                    {
                        var noResponse = response.StatusCode.ToString();
                        return View(noResponse);
                    }
                }
            }
            return View(results);
        }
       
       
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            var results = new CarServiceType();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"{apiUrl}/{id}"))
                {
                   
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<CarServiceType>(apiResponse);
                }
            }
            return RedirectToAction("GetServiceType");
        }

        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CarServiceType carServiceType)
        {
            var resService= new CarServiceType();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(carServiceType), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiUrl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resService = JsonConvert.DeserializeObject<CarServiceType>(apiResponse);
                }
            }
            return RedirectToAction("GetServiceType");
        }

        public async Task<IActionResult> EditServiceType(int id)
        {
            var carService = new CarServiceType();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.GetAsync($"{apiUrl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    carService = JsonConvert.DeserializeObject<CarServiceType>(apiResponse);
                }
            }
            return View(carService);
        }


        [HttpPost]

        public async Task<IActionResult> EditServiceType(int id, CarServiceType carServ)
        {
            var rescharacter = new CarServiceType();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(carServ), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiUrl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    rescharacter = JsonConvert.DeserializeObject<CarServiceType>(apiResponse);
                }
            }
            return RedirectToAction("GetServiceType");
        }

    }
}
