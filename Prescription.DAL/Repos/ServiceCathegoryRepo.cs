using Dapper.Contrib.Extensions;
using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos
{
    public class ServiceCathegoryRepo 
    {
        IDbConnection _connection;
        public ServiceCathegoryRepo(IDbConnection connection)  
        {
            _connection = connection;
        }
        public ServiceCathegory GetOne(long id) => _connection.Get<ServiceCathegory>(id);
        public List<ServiceCathegory> GetAll() => _connection.GetAll<ServiceCathegory>().ToList();
        
    }
}
