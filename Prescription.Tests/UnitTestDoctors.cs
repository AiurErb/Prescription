using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescription.Tests
{
    public class UnitTestDoctors
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
        SqlConnection connection;

        [Fact]
        public void GetOne()
        {
            connection = new SqlConnection(connectionString);
            DoctorRepo repo = new DoctorRepo(connection);
            Doctor doctor = repo.GetOne(1);
            Assert.Equal("Ulrich Peters", doctor.Name);
            Assert.NotNull(doctor.CurrentAddress);
            Assert.Equal(5, doctor.CurrentAddress.Id);
        }
        [Fact]
        public async Task GetAllAsync()
        {
            connection = new SqlConnection(connectionString);
            var repo = new DoctorRepo(connection);
            var list = await repo.GetAll();
            Assert.Equal(2, list.Count());
            Doctor doctor = list[0];
            Assert.Equal(5, doctor.CurrentAddress?.Id);
        }
        //[Fact]
        //public void AddAddress()
        //{
        //    connection = new SqlConnection(connectionString);
        //    var repo = new DoctorRepo(connection);
        //    var doctor = repo.GetOne(1);
        //    Assert.Single<DoctorsAddress>(doctor.CurrentAddress);
        //    var newAddress = new DoctorsAddress 
        //    {
        //        Street ="KalkHauptstaße",
        //        Haus="23",
        //        ZIP="51102",
        //        City="Köln",
        //        DoctorId=doctor.Id,
        //        Current=false
        //    };
        //    var addressRepo = new DoctorsAddressRepo(connection);
        //    addressRepo.Insert(newAddress);
        //    Assert.Equal(2,repo.GetAddresses(doctor).Count());
        //    Assert.Equal("23a", repo.GetCurrentAddress(doctor)?.Haus.Trim());
        //    addressRepo.Delete(newAddress);

        //}
    }
}
