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
            Assert.Equal("Dr. Horst", repo.GetOne(1)?.Name);
        }
        [Fact]
        public async Task GetAllAsync()
        {
            connection = new SqlConnection(connectionString);
            var repo = new DoctorRepo(connection);
            var list = await repo.GetAll();
            Assert.Equal(2, list.Count());
        }
        [Fact]
        public void AddAddress()
        {
            connection = new SqlConnection(connectionString);
            var repo = new DoctorRepo(connection);
            var doctor = repo.GetOne(1);
            Assert.Single<DoctorsAddress>(repo.GetAddresses(doctor));
            var newAddress = new DoctorsAddress 
            {
                Street ="KalkHauptstaße",
                Haus="23",
                ZIP="51102",
                City="Köln",
                DoctorId=doctor.Id,
                Current=false
            };
            var addressRepo = new DoctorsAddressRepo(connection);
            addressRepo.Insert(newAddress);
            Assert.Equal(2,repo.GetAddresses(doctor).Count());
            Assert.Equal("23a", repo.GetCurrentAddress(doctor)?.Haus.Trim());
            addressRepo.Delete(newAddress);

        }
    }
}
