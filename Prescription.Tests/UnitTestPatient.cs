using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities;
using Prescription.DAL.Repos;

namespace Prescription.Tests
{
    public class UnitTestPatient
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrescriptionDb;Integrated Security=True;";
        SqlConnection connection;
        [Fact]
        public void GetOnePatient()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo= new PatientRepo(connection);
            Assert.Equal("Robert Höpgen", repo.GetOne(1)?.Name);
        }
        [Fact]
        public async void GetAllPatients()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo= new PatientRepo(connection);
            var list = await repo.GetAll();
            Assert.Equal(2, list.Count());

        }
        [Fact]
        public async void AddPatient()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo = new PatientRepo(connection);
            Patient newPatient = new Patient
            {
                Name = "Tunkay Dogu",
                InsuranceNumber = "17832164H",
                Birthday = new DateTime(1960, 10, 15),

            };
            long id = repo.Insert(newPatient);
            var list = await repo.GetAll();
            Assert.Equal(id, list.Count());
        }
        [Fact]
        public void UpdatePatient()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo = new PatientRepo(connection);
            Patient? updatedPatient = repo.GetOne(3);
            DateTime newBirthday = new DateTime(1958, 10, 15);
            updatedPatient.Birthday = newBirthday;
            repo.Update(updatedPatient);
            Assert.Equal(newBirthday, repo.GetOne(3).Birthday);

        }
        [Fact]
        public async void DeletePatient()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo = new PatientRepo(connection);
            Patient? deletePatient = repo.GetOne(3);
            repo.Delete(deletePatient);
            var list = await repo.GetAll();
            Assert.Equal(2, list.Count());
        }
        [Fact]
        public void AddPatientWithAddress()
        {
            connection = new SqlConnection(connectionString);
            Patient newPatient = new Patient
            {
                Name = "Fatima Barzizuzoy",
                InsuranceNumber = "45R87691",
                Birthday = new DateTime(1948, 8, 15)
            };
            List<PatientsAddress> addresses = new List<PatientsAddress>
            {
                new PatientsAddress {Street="Ostheimer str.", Haus="12"},
                new PatientsAddress {Street="Hartenberg str.", Haus="54f",Current=true}
            };
            newPatient.Addresses=addresses;
            PatientRepo repo = new PatientRepo(connection);
            long insert = repo.Insert(newPatient);
            Assert.Equal(2, repo.GetOne(insert).Addresses.Count);

        }
        [Fact]
        public void SetUpCurrentAddress()
        {
            connection = new SqlConnection(connectionString);
            PatientsAddressRepo repo = new PatientsAddressRepo(connection);
            bool setUp = repo.SetCurrent(1001, 1001);
            Assert.True(setUp);
            PatientRepo patientRepo = new PatientRepo(connection);
            Patient patient = patientRepo.GetOne(1001);
            PatientsAddress address = patient.CurrentAddress;
            Assert.Equal(1001, address.Id);
        }
        [Fact]
        public void GetPatientWithAddress()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo = new PatientRepo(connection);
            Patient? patient = repo.GetOne(1);
            PatientsAddress address = patient.Addresses.First();
            Assert.Equal("Mülheimerstr.", address.Street);
        }
        [Fact] 
        public void GetAddresses()
        {
            connection = new SqlConnection(connectionString);
            PatientRepo repo = new PatientRepo(connection);
            List<DoctorsAddress> addresses = repo.GetDepend<DoctorsAddress>
                (1, "DoctorId");
            Assert.NotEmpty(addresses);
        }

    }
}
