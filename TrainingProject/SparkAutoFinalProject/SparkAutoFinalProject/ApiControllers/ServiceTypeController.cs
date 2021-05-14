using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spark.DataLayer;
using Spark.DataModel.Models;
using Spark.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAutoFinalProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        //private static CarServiceType dd = new CarServiceType();
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public ServiceTypeController(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }


        public IActionResult GetServiceType()
        {
            var serviceType = _serviceTypeRepository.GetServiceType();
            return Ok(serviceType);
        }
        [HttpGet("{id}")]
        public IActionResult GetServiceTypeById(int id)
        {
            var typeId = _serviceTypeRepository.GetServiceTypeById(id);
            return Ok(typeId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServiceType(int id)
        {
            var res = _serviceTypeRepository.DeleteServiceType(id);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateServiceType(int id,CarServiceType carServiceType)
        {
            var resUpdate = _serviceTypeRepository.EditServiceType(id,carServiceType);
            return Ok(resUpdate);
        }
        [HttpPost]
        public IActionResult InsertServiceType(CarServiceType carServiceType)
        {
            var insert = _serviceTypeRepository.InsertServiceType(carServiceType);
            return Ok(insert);
        }


    }
}
