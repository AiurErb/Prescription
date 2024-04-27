using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Data;

namespace Prescription.DAL.Repos
{
    public class DoctorRepo : RepoBase<Doctor>
    {
        public DoctorRepo(IDbConnection connection) : base(connection) { }
        //public List<DoctorsAddress> GetAddresses(Doctor doctor)
        //{
        //    DoctorsAddressRepo addresses = new DoctorsAddressRepo(_connection);
        //    return addresses.GetByDoctor(doctor.Id).ToList();
        //}
        //public DoctorsAddress? GetCurrentAddress(Doctor doctor)
        //{
        //    return GetAddresses(doctor).FirstOrDefault(address => address.Current == true);
        //}
        public override async Task<List<Doctor>> GetAll()
        {            
            var output = await _connection.GetAllAsync<Doctor>();
            //foreach (Doctor doctor in output)
            //{
            //    doctor.CurrentAddress = GetCurrentAddress(doctor);
            //}
            return new DbAddressRepo(_connection)
                .AllOwnerWithCurrentAddress<Doctor>(AddressOwner.Doctor);
        }
        public override Doctor GetOne(long id)
        {
            //Doctor output = base.GetOne(id);
            //output.CurrentAddress = GetCurrentAddress(output);
            return new DbAddressRepo(_connection)
                .OneAddressOwner<Doctor>(id,AddressOwner.Doctor);
        }
    }
}
