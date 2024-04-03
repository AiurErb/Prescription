using Dapper;
using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos
{
    public class DoctorsAddressRepo: RepoBase<DoctorsAddress>
    {
        public DoctorsAddressRepo(IDbConnection connection) : base(connection) { }
        public List<DoctorsAddress> GetByDoctor(long id) 
        {
            string sql = "SELECT * FROM dbo.DoctorsAddress WHERE DoctorId=@id";
            return _connection.Query<DoctorsAddress>(sql, new {id=id}).ToList();
        }
    }
}
