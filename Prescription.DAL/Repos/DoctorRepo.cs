using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Prescription.DAL.Repos
{
    public class DoctorRepo : RepoBase<Doctor>
    {
        public DoctorRepo()
        {
            ConnectToDb connectToDb = new ConnectToDb();
            _connection = connectToDb.GetConnection();
        }
        public List<DoctorsAddress> GetAddresses(Doctor doctor)
        {
            DoctorsAddressRepo addresses = new DoctorsAddressRepo();
            return addresses.GetByDoctor(doctor.Id).ToList();
        }
        public DoctorsAddress? GetCurrentAddress(Doctor doctor)
        {
            return GetAddresses(doctor).FirstOrDefault(address => address.Current == true);
        }
    }
}
