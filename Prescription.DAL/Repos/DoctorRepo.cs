using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Data;
using Dapper;
using Prescription.DAL.Interfaces;

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
            string sql = $@"
            SELECT * FROM dbo.Doctor owner
            LEFT JOIN dbo.Address address
            ON owner.Id=address.OwnerId AND OwnerType=@type AND [Current]=1";

            var output = _connection.Query<Doctor, Address, Doctor>(sql, (owner, address) =>
            {
                owner.CurrentAddress = address;
                return owner;
            },
            new { type = (int)AddressOwner.Doctor });
            return output.ToList();
            //var output = await _connection.GetAllAsync<Doctor>();
            //foreach (Doctor doctor in output)
            //{
            //    doctor.CurrentAddress = GetCurrentAddress(doctor);
            //}
            //return new DbAddressRepo(_connection)
                //.AllOwnerWithCurrentAddress<Doctor>(AddressOwner.Doctor);
        }
        public override Doctor GetOne(long id)
        {
            //IDbTransaction transaction = _connection.BeginTransaction();
            Doctor output = base.GetOne(id);
            output.CurrentAddress = 
                new DbAddressRepo(_connection)
                .GetCurrentAddress(output.Id,AddressOwner.Doctor);
            //transaction.Commit();
            return output;
        }
    }
}
