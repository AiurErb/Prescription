using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;


namespace Prescription.Tests.DoctorTests
{
    public class UnitTestDoctor
    {
        private DoctorRepo repo;
        private DbAddressRepo addressRepo;
        
        public UnitTestDoctor()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            repo = new DoctorRepo(connection);
            addressRepo = new DbAddressRepo(connection);
        }
        [Fact]
        public void TestGetOneDoctor()
        {
            //Arrange
            Doctor doctor = new Doctor();
            //Act
            doctor = repo.GetOne(1007);
            //Assertion
            Assert.NotNull(doctor);
            Assert.NotNull(doctor.CurrentAddress);
            Assert.Equal("Doctor2", doctor.Name);
            Assert.Equal("Vorgebirsstraße", doctor.CurrentAddress.Street);
        }
        [Fact]
        public void TestGetOneWrongDoctor()
        {
            //Arrange
            Doctor coctor = new Doctor();
            long id = 5555;

            //Act
            Doctor doctor = repo.GetOne(id);
            //Assertion
            Assert.Null(doctor);
        }
        [Fact]
        public async Task TestGetAllDoctorsWithFilter()
        {
            //Arrange
            List<Doctor> doctors = new();
            //Act
            doctors = await repo.GetAll();
            //Assertion
            Assert.Equal(4, doctors.Count);
            Doctor doctor = doctors.FirstOrDefault(doctor => doctor.Id == 1007);
            Assert.NotNull(doctor.CurrentAddress);
            Assert.Equal("Vorgebirsstraße", doctor.CurrentAddress.Street);

        }
        [Fact]
        public async Task TestGetAllDoctorsWithoutFilter() 
        {
            //Arrange
            List<Doctor> doctors = new();
            //Act
            doctors = await repo.GetAll(filter: false);
            //Assertion
            Assert.Equal(5, doctors.Count);
            Doctor doctor = doctors.FirstOrDefault(doctor => doctor.Id == 1007);
            Assert.NotNull(doctor.CurrentAddress);
            Assert.Equal("Vorgebirsstraße", doctor.CurrentAddress.Street);
        }
        [Fact]
        public async Task TestGetPageDoctors()
        {
            //Arrange
            List<Doctor> doctorsPage = new();
            int page = 1;
            int pageSize = 5;
            //Act
            doctorsPage = await repo.GetPage(page, pageSize);
            //Assertion
            Assert.Equal(5,doctorsPage.Count);
        }
        [Fact]
        public void TestAddDoctorWithoutAddress() 
        {
            //Arrange
            Doctor newDoctor = new Doctor
            {
                Name = "Doctor1",
                LANR = "1111111"
            };
            //Act
            long id = repo.Insert(newDoctor);

            //Assertion
            Doctor insertedDoctor = repo.GetOne(id);
            Assert.Equal("Doctor1", insertedDoctor.Name);
            Assert.Equal("Unbekannt", insertedDoctor.CurrentAddress.City);
        }
        [Fact]
        public void TestAddDoctorWithAddress() 
        {
            //Arrange
            Doctor newDoctor = new Doctor
            {
                Name = "Doctor2",
                LANR = "2222222"
            };
            DbAddress doctorsAddress = new DbAddress
            {
                City = "Köln",
                ZIP = "50969",
                Street = "Vorgebirsstraße",
                Haus = "51",
                OwnerType = (int)AddressOwner.Doctor
            };
            //Act
            long doctorId = repo.Insert(newDoctor);
            doctorsAddress.OwnerId = doctorId;
            long addressId = addressRepo.Insert(doctorsAddress);
            //Assertion
            Doctor insertedDoctor = repo.GetOne(doctorId);
            Assert.Equal("Doctor2", insertedDoctor.Name);
            Assert.Equal("Vorgebirsstraße", insertedDoctor.CurrentAddress.Street);
        }
        [Fact]
        public void TestUpdateDoctor() 
        {
            //Arrange
            Doctor editDoctor = repo.GetOne(1003);
            editDoctor.Name = "Doctor3";
            //Act
            repo.Update(editDoctor);
            //Assertion
            Doctor updatedDoctor = repo.GetOne(1003);
            Assert.Equal("Doctor3", updatedDoctor.Name);
            //Restore
            updatedDoctor.Name = "Doctor1";
            repo.Update(updatedDoctor);
        }
        [Fact]
        public void TestUpdateDoctorsAddress() { throw new NotImplementedException(); }
        [Fact]
        public void TestMarkDoctorAsDeleted() { throw new NotImplementedException(); }
    }
}
