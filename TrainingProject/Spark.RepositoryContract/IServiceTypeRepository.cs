using Spark.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spark.RepositoryContract
{
    public interface IServiceTypeRepository
    {
        IEnumerable<CarServiceType> GetServiceType();
        
        CarServiceType GetServiceTypeById(int serviceTypeId);

        CarServiceType InsertServiceType(CarServiceType carService);
        CarServiceType EditServiceType(int id,CarServiceType carServiceType);
        CarServiceType DeleteServiceType(int serviceTypeId);

    }
}
