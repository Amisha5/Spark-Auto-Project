using Microsoft.EntityFrameworkCore;
using Spark.DataLayer;
using Spark.DataModel.Models;
using Spark.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.RepositoryLayer
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly SparkDbContext _sparkDbContext;
        public ServiceTypeRepository(SparkDbContext sparkDbContext)
        {
            _sparkDbContext = sparkDbContext;
        }

        public CarServiceType DeleteServiceType(int serviceId)
        {
            var deleteType = _sparkDbContext.CarServiceTypes.Where(e => e.Id == serviceId).FirstOrDefault();
            _sparkDbContext.CarServiceTypes.Remove(deleteType);
            _sparkDbContext.SaveChanges();
            return deleteType;
        }

        public CarServiceType EditServiceType(int id,CarServiceType carServiceType)
        {
            var servicetype = _sparkDbContext.CarServiceTypes.Where(e => e.Id == carServiceType.Id).FirstOrDefault();
            servicetype.Name = carServiceType.Name;
            servicetype.Price = carServiceType.Price;
            _sparkDbContext.SaveChanges();
            return servicetype;
        }

        public IEnumerable<CarServiceType> GetServiceType()
        {
            var res = _sparkDbContext.CarServiceTypes.ToList();
            return res;
        }

        public CarServiceType GetServiceTypeById(int serviceTypeId)
        {
            var typeId = _sparkDbContext.CarServiceTypes.FirstOrDefault(c=>c.Id == serviceTypeId);
            return typeId;

        }

        public CarServiceType InsertServiceType(CarServiceType carServicetype)
        {
            var insertCar = _sparkDbContext.CarServiceTypes.Add(carServicetype);
            _sparkDbContext.SaveChanges();
            return carServicetype;
        }
    }
}
